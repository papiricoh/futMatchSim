using System;
using futMatchSim.Models;
using SDL2;

namespace futMatchSim
{
	public class VisualManager
	{
        private IntPtr renderer;
        private IntPtr ventana;

        private static int windowWidth = 800;
        private static int windowHeight = 600;
        public static int centerX = windowWidth / 2; 
        public static int centerY = windowHeight / 2;

        public float scaleX = 3;
        public float scaleY = 3;

        public VisualManager()
        {
            Console.WriteLine("DEV Interface INIT");
            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) < 0)
            {
                Console.WriteLine("Error al inicializar SDL: " + SDL.SDL_GetError());
                return;
            }

            // Crear la ventana
            ventana = SDL.SDL_CreateWindow(
                "Simulación de Jugadores 2D",
                SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED,
                windowWidth, windowHeight,
                SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);

            if (ventana == IntPtr.Zero)
            {
                Console.WriteLine("Error al crear la ventana: " + SDL.SDL_GetError());
                return;
            }

            // Crear el renderer
            renderer = SDL.SDL_CreateRenderer(ventana, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);

            if (renderer == IntPtr.Zero)
            {
                Console.WriteLine("Error al crear el renderer: " + SDL.SDL_GetError());
                return;
            }
        }

        public IntPtr getRenderer()
        {
            return this.renderer;
        }

        public void quitScreen()
        {
            SDL.SDL_DestroyRenderer(renderer);
            SDL.SDL_DestroyWindow(ventana);
            SDL.SDL_Quit();
        }

        public void debugRender() //DEBUG RENDER
        {

            SDL.SDL_Event e;
            while (SDL.SDL_PollEvent(out e) != 0)
            {
                if (e.type == SDL.SDL_EventType.SDL_QUIT)
                {
                    quitScreen();
                    return;
                }
            }

            SDL.SDL_SetRenderDrawColor(renderer, 0, 128, 255, 255);
            SDL.SDL_RenderClear(renderer);


            drawField();

            foreach (PlayerEntity player in Program.getInstance().GetGameManager().getHomePlayers())
            {
                

                SDL.SDL_SetRenderDrawColor(renderer, 255, 0, 0, 255);

                int xPos = (int) (player.getPosition().X * scaleX);
                int yPos = (int) (player.getPosition().Y * scaleY);


                int screenX = VisualManager.centerX + xPos;
                int screenY = VisualManager.centerY - yPos;


                SDL.SDL_Rect playerRect = new SDL.SDL_Rect
                {
                    x = screenX,
                    y = screenY,
                    w = 10,
                    h = 10
                };

                SDL.SDL_RenderFillRect(renderer, ref playerRect);
            }

            foreach (PlayerEntity player in Program.getInstance().GetGameManager().getAwayPlayers())
            {


                SDL.SDL_SetRenderDrawColor(renderer, 0, 0, 255, 255);

                int xPos = (int)(player.getPosition().X * scaleX);
                int yPos = (int)(player.getPosition().Y * scaleY);


                int screenX = VisualManager.centerX + xPos;
                int screenY = VisualManager.centerY - yPos;


                SDL.SDL_Rect playerRect = new SDL.SDL_Rect
                {
                    x = screenX,
                    y = screenY,
                    w = 10,
                    h = 10
                };

                SDL.SDL_RenderFillRect(renderer, ref playerRect);
            }

            Ball ball = Program.getInstance().GetGameManager().ball;

            SDL.SDL_SetRenderDrawColor(renderer, 255, 255, 255, 255);

            int ballXPos = (int) ball.getPosition().X;
            int ballYPos = (int) ball.getPosition().Y;


            int ballScreenX = VisualManager.centerX + ballXPos;
            int ballScreenY = VisualManager.centerY - ballYPos;

            SDL.SDL_Rect ballRect = new SDL.SDL_Rect
            {
                x = ballScreenX,
                y = ballScreenY,
                w = 5,
                h = 5
            };

            SDL.SDL_RenderFillRect(renderer, ref ballRect);


            SDL.SDL_RenderPresent(renderer);
        }

        private void drawField()
        {
            SDL.SDL_SetRenderDrawColor(renderer, 0, 128, 0, 255);
            SDL.SDL_RenderClear(renderer);

            // Dibujar las líneas del campo de fútbol en blanco
            SDL.SDL_SetRenderDrawColor(renderer, 255, 255, 255, 255);

            Field field = Program.getInstance().GetGameManager().field;



            // Dibujar las líneas laterales (bordes del campo)
            SDL.SDL_Rect campoRect = new SDL.SDL_Rect
            {
                x = centerX - (int)(field.height / 2 * scaleX),
                y = centerY - (int)(field.width / 2 * scaleY),
                w = (int)(field.height * scaleX),
                h = (int)(field.width * scaleY)
            };
            SDL.SDL_RenderDrawRect(renderer, ref campoRect);

            // Dibujar la línea central
            SDL.SDL_RenderDrawLine(renderer, centerX, centerY - (int)(field.width / 2 * scaleY),
                                                 centerX, centerY + (int)(field.width / 2 * scaleY));

            // Dibujar el círculo central
            DrawCircle(renderer, centerX, centerY, (int)(9.15 * scaleX)); // Círculo con radio de 9.15 metros (diámetro 18.30 metros)

            // Dibujar las porterías
            DrawGoal(renderer, centerX, centerY, scaleX, scaleY, field.height, field.width);

        }

        static void DrawCircle(IntPtr renderer, int centerX, int centerY, int radius)
        {
            int offsetX = 0;
            int offsetY = radius;
            int d = radius - 1;
            while (offsetY >= offsetX)
            {
                SDL.SDL_RenderDrawPoint(renderer, centerX + offsetX, centerY + offsetY);
                SDL.SDL_RenderDrawPoint(renderer, centerX + offsetY, centerY + offsetX);
                SDL.SDL_RenderDrawPoint(renderer, centerX - offsetX, centerY + offsetY);
                SDL.SDL_RenderDrawPoint(renderer, centerX - offsetY, centerY + offsetX);
                SDL.SDL_RenderDrawPoint(renderer, centerX + offsetX, centerY - offsetY);
                SDL.SDL_RenderDrawPoint(renderer, centerX + offsetY, centerY - offsetX);
                SDL.SDL_RenderDrawPoint(renderer, centerX - offsetX, centerY - offsetY);
                SDL.SDL_RenderDrawPoint(renderer, centerX - offsetY, centerY - offsetX);

                if (d >= 2 * offsetX)
                {
                    d -= 2 * offsetX + 1;
                    offsetX += 1;
                }
                else if (d < 2 * (radius - offsetY))
                {
                    d += 2 * offsetY - 1;
                    offsetY -= 1;
                }
                else
                {
                    d += 2 * (offsetY - offsetX - 1);
                    offsetY -= 1;
                    offsetX += 1;
                }
            }
        }

        // Función para dibujar las porterías
        static void DrawGoal(IntPtr renderer, int centerX, int centerY, float escalaX, float escalaY, float campoLargo, float campoAncho)
        {
            // Tamaño de la portería en metros
            float porteriaAncho = 7.32f;
            float porteriaAlto = 2.44f;

            // Dibujar la portería izquierda
            SDL.SDL_Rect porteriaIzquierda = new SDL.SDL_Rect
            {
                x = centerX - (int)((campoLargo / 2 * escalaX) + (2 * escalaX)),
                y = centerY - (int)(porteriaAncho / 2 * escalaY),
                w = (int)(2 * escalaX),
                h = (int)(porteriaAncho * escalaY)
            };
            SDL.SDL_RenderDrawRect(renderer, ref porteriaIzquierda);

            // Dibujar la portería derecha
            SDL.SDL_Rect porteriaDerecha = new SDL.SDL_Rect
            {
                x = centerX + (int)(campoLargo / 2 * escalaX),
                y = centerY - (int)(porteriaAncho / 2 * escalaY),
                w = (int)(2 * escalaX), // La profundidad de la portería es pequeña, aprox. 2 metros
                h = (int)(porteriaAncho * escalaY)
            };
            SDL.SDL_RenderDrawRect(renderer, ref porteriaDerecha);
        }

    }
}

