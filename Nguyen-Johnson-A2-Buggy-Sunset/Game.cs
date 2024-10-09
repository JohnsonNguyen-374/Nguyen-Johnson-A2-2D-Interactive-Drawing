// Include code libraries you need below (use the namespace).
using Game10003;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

// The namespace your code is in.
namespace Game10003;

/// <summary>
///     Your game code goes inside this class!
/// </summary>
public class Game
{
    // Place your variables here:
    private int bodySize = 60;
    private int eyeSize = 20;
    private int pupilSize = 5;
    private int pairRowCount = 1;
    private int pairColumnCount = 2;
    private int bodyRowCount = 1;
    private int bodyColumnCount = 9;
    private int grassRowCount = 1;
    private int grassColumnCount = 50;
    private int sunSize = 240;
    private int cloudRowCount = 1;
    private int cloudColumnCount = 4;
    private int cloudSize = 40;
    private Color eyeColor;
    private Color bodyColor;
    private Color skyColor;
    private Color sunColor;
    bool isColorUpdate;

    // Declare what Colors are in the Array
    Color[] colorEyeArray = { Color.Red, Color.Blue, Color.Green, Color.Yellow, new Color(128, 0, 128), Color.White };
    Color[] colorBodyArray = { new Color(255, 51, 204), Color.Cyan, new Color(0, 102, 0), new Color(102, 51, 0), new Color(102, 0, 102), Color.Black };
    Color[] colorSkyArray = { new Color(106, 211, 235), new Color(255, 153, 51), new Color(11, 11, 77) };
    Color[] colorSunArray = { Color.Yellow, new Color(255, 102, 0), Color.LightGray };

    // Declare a Random Integer for the Eye Color Array
    int randomEyeColorArray = Random.Integer(0, 6);

    // Declare a Random Integer for the Body Color Array
    int randomBodyColorArray = Random.Integer(0, 6);

    // Set Initial Value for Sky and Sun Color from Array
    int initialSkyColor = (1);
    int initialSunColor = (1);

    /// <summary>
    ///     Setup runs once before the game loop begins.
    /// </summary>
    public void Setup()
    {
        // Canvas Window Setup
        Window.SetTitle("Buggy Sunset");
        Window.SetSize(800, 600);
        Window.TargetFPS = 30;

        // Assigning the Value of the Array to a Seperate Variable
        eyeColor = colorEyeArray[randomEyeColorArray];
        bodyColor = colorBodyArray[randomBodyColorArray];
        skyColor = colorSkyArray[initialSkyColor];
        sunColor = colorSunArray[initialSunColor];
        isColorUpdate = true;
    }

    /// <summary>
    ///     Update runs every frame.
    /// </summary>
    public void Update()
    {
        Window.ClearBackground(Color.Black);

        // Draw the Sky
        Draw.LineColor = Color.Clear;
        Draw.LineSize = 2;
        Draw.FillColor = skyColor;
        Draw.Rectangle(0, 0, 800, 350);

        // Draw the Sun 
        Draw.LineColor = Color.White;
        Draw.LineSize = 2;
        Draw.FillColor = sunColor;
        Draw.Circle(400, 300, sunSize);

        //Draw the Cloud
        // GRID drawing with "Nested" for loops
        for (int x = 0; x < cloudColumnCount; x++)
        {
            for (int y = 0; y < cloudRowCount; y++)
            {
                int xPos = x * 40;
                int yPos = y * 40;
                Draw.LineColor = Color.Clear;
                Draw.LineSize = 2;
                Draw.FillColor = Color.White;
                Draw.Circle(100 + xPos, 100 + yPos, cloudSize);
            }
        }

        //Draw the other Cloud
        // GRID drawing with "Nested" for loops
        for (int x = 0; x < cloudColumnCount; x++)
        {
            for (int y = 0; y < cloudRowCount; y++)
            {
                int xPos = x * 40;
                int yPos = y * 40;
                Draw.LineColor = Color.Clear;
                Draw.LineSize = 2;
                Draw.FillColor = Color.White;
                Draw.Circle(500 + xPos, 150 + yPos, cloudSize);
            }
        }

        // Draw the Grass
        Draw.LineColor = Color.Clear;
        Draw.LineSize = 2;
        Draw.FillColor = new Color(0, 204, 0);
        Draw.Rectangle(0, 350, 800, 250);

        // Draw the Blades of Grass
        // GRID drawing with "Nested" for loops
        for (int x = 0; x < grassColumnCount; x++)
        {
            for (int y = 0; y < grassRowCount; y++)
            {
                int xPos = x * 20;
                int yPos = y * 20;
                Draw.LineColor = Color.Clear;
                Draw.LineSize = 2;
                Draw.FillColor = new Color(0, 204, 0);
                Draw.Triangle(-20 + xPos, 350 + yPos, 20 + xPos, 350 + yPos, 40 + xPos, 310 + yPos);
            }
        }

        // Draw the Bug's Body
        // GRID drawing with "Nested" for loops
        for (int x = 0; x < bodyColumnCount; x++)
        {
            for (int y = 0; y < bodyRowCount; y++)
            {
                int xPos = x * 60;
                int yPos = y * 60;
                Draw.LineColor = Color.Clear;
                Draw.LineSize = 2;
                Draw.FillColor = bodyColor;
                Draw.Circle(150 + xPos, 300 + yPos, bodySize);
            }
        }

        //Draw the Bug's Eyes
        // GRID drawing with "Nested" for loops
        for (int x = 0; x < pairColumnCount; x++)
        {
            for (int y = 0; y < pairRowCount; y++)
            {
                int xPos = x * 60;
                int yPos = y * 60;
                Draw.LineColor = Color.White;
                Draw.LineSize = 2;
                Draw.FillColor = eyeColor;
                Draw.Circle(605 + xPos, 280 + yPos, eyeSize);
            }
        }

        //Draw the Bug's Pupils
        // GRID drawing with "Nested" for loops
        for (int x = 0; x < pairColumnCount; x++)
        {
            for (int y = 0; y < pairRowCount; y++)
            {
                int xPos = x * 60;
                int yPos = y * 60;
                Draw.LineColor = Color.White;
                Draw.LineSize = 2;
                Draw.FillColor = Color.Black;
                Draw.Circle(615 + xPos, 275 + yPos, pupilSize);
            }
        }

        // Check for User Mouse Click to decide whether to go the "Next" or "Previous" Color in the Array ("colorEyeArray")
        if (Input.IsMouseButtonPressed(MouseInput.Right))
        {
            if (isColorUpdate)
                eyeColor = colorEyeArray[randomEyeColorArray++];
        }
        else if (Input.IsMouseButtonPressed(MouseInput.Left))
        {
            if (isColorUpdate)
                eyeColor = colorEyeArray[randomEyeColorArray--];
        }

        // Check if the variable randomEyeColorArray for if it goes beyond Array length, determine whether to reset or loop
        if (randomEyeColorArray > 5)
        {
            randomEyeColorArray = 0;
        }
        else if (randomEyeColorArray < 0)
        {
            randomEyeColorArray = 5;
        }

        // Check for User Space Key Click to randomize Bug's Body Color, pulling from the Array ("colorBodyArray")
        if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
        {
            if (isColorUpdate)
            {
                int randomBodyColor = Random.Integer(0, 6);
                bodyColor = colorBodyArray[randomBodyColor];
            }
        }

        // Check for User Left Mouse Click to go to the "Next" Color in the Array ("colorSkyArray)
        if (Input.IsKeyboardKeyPressed(KeyboardInput.T))
        {
            if (isColorUpdate)
                skyColor = colorSkyArray[initialSkyColor++];
            sunColor = colorSunArray[initialSunColor++];
        }

        // Check if the variable initialSkyColor if it goes beyond Array length, determine whether to reset or loop
        if (initialSkyColor > 2)
        {
            initialSkyColor = 0;
            initialSunColor = 0;
        }
    }
}