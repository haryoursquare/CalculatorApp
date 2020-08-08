
/*
MainActivity.cs
Ayodele Ayorinde
07/08/2020
A calculator android application built with Xamarin.
This file handles the backend functionality when you press a button
on the calculator.
 */
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;
namespace AyoTech {
    [Activity(Label = "AyoTech", MainLauncher = true, Icon = "@drawable/icon")]

    /*
     * MainActivity class, since our application resides on one screen
     * All of the button press events will go into this activity.
     */
    public class MainActivity : Activity {

        //math operations
        private enum MATH_OPERATION { ADD, SUBTRACT, DIVIDE, MULTIPLY, POWER,SQRT };

        MATH_OPERATION? mathOperation = null;

        decimal? firstNumber = null;
        decimal? secondNumber = null;

        //creates the UI for us
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);


            // Get all of our number buttons
            Button btn1 = (Button)FindViewById(Resource.Id.btn1);
            Button btn2 = (Button)FindViewById(Resource.Id.btn2);
            Button btn3 = (Button)FindViewById(Resource.Id.btn3);
            Button btn4 = (Button)FindViewById(Resource.Id.btn4);
            Button btn5 = (Button)FindViewById(Resource.Id.btn5);
            Button btn6 = (Button)FindViewById(Resource.Id.btn6);
            Button btn7 = (Button)FindViewById(Resource.Id.btn7);
            Button btn8 = (Button)FindViewById(Resource.Id.btn8);
            Button btn9 = (Button)FindViewById(Resource.Id.btn9);
            Button btn0 = (Button)FindViewById(Resource.Id.btn0);

            //function buttons
            Button btnAdd = (Button)FindViewById(Resource.Id.btnAdd);
            Button btnSubtract = (Button)FindViewById(Resource.Id.btnSubtract);
            Button btnMultiply = (Button)FindViewById(Resource.Id.btnMultiply);
            Button btnDivide = (Button)FindViewById(Resource.Id.btnDivide);
            Button btnEquals = (Button)FindViewById(Resource.Id.btnEquals);
            Button btnClear = (Button)FindViewById(Resource.Id.btnClear);
            Button btnDelete = (Button)FindViewById(Resource.Id.btnDelete);
            Button btnRoot = (Button)FindViewById(Resource.Id.btnRoot);
            Button btnSquared = (Button)FindViewById(Resource.Id.btnSquared);
            Button btnPower = (Button)FindViewById(Resource.Id.btnPower);
            Button btnDecimal = (Button)FindViewById(Resource.Id.btnDecimal);
            Button btnPlusMinus = (Button)FindViewById(Resource.Id.btnPlusMinus);
            Button btnPercent = (Button)FindViewById(Resource.Id.btnPercent);


            //display text
            TextView textDisplay = (TextView)FindViewById(Resource.Id.textDisplay);



            /* Button 1
             * Adds 1 to the display */
            btn1.Click += delegate {
                addToCurrentDisplayedValue(textDisplay, "1");
            };

            /* Button 2 
             *Adds 2 to the display
             */
            btn2.Click += delegate {
                addToCurrentDisplayedValue(textDisplay, "2");
            };

            /* Button 3 
             *Adds 3 to the display
             */
            btn3.Click += delegate {
                addToCurrentDisplayedValue(textDisplay, "3");
            };

            /* Button 4 
             *Adds 4 to the display
             */
            btn4.Click += delegate {
                addToCurrentDisplayedValue(textDisplay, "4");
            };

            /*
             * Button 5 
             *Adds 5 to the display
             */
            btn5.Click += delegate {
                addToCurrentDisplayedValue(textDisplay, "5");
            };

            /* Button 6
             * Adds 6 to the display */
            btn6.Click += delegate {
                addToCurrentDisplayedValue(textDisplay, "6");
            };

            /* Button 7
             * Adds 7 to the display */
            btn7.Click += delegate {
                addToCurrentDisplayedValue(textDisplay, "7");
            };

            /* Button 8 
             * Adds 8 to the display */
            btn8.Click += delegate {
                addToCurrentDisplayedValue(textDisplay, "8");
            };

            /* Button 9 
             * Adds 9 to the display*/
            btn9.Click += delegate {
                addToCurrentDisplayedValue(textDisplay, "9");
            };

            /* Button 0 
             * Adds 0 to the display*/
            btn0.Click += delegate {
                addToCurrentDisplayedValue(textDisplay, "0");
            };

            /* Add Button 
             * Event for when the add button is clicked, saves the number into
             memory then clears the screen for the next number to be entered*/
            btnAdd.Click += delegate {
                mathOperation = MATH_OPERATION.ADD;
                saveNumberToMemory(textDisplay);
                clearDisplay(textDisplay);
            };

            /* Subtract Button 
             * Event for when the subctract button is clicked, saves the number into
             memory then clears the screen for the next number to be entered*/
            btnSubtract.Click += delegate {
                mathOperation = MATH_OPERATION.SUBTRACT;
                saveNumberToMemory(textDisplay);
                clearDisplay(textDisplay);
            };

            /* Multiply Button 
             * Event for when the multiply button is clicked, saves the number into
             memory then clears the screen for the next number to be entered*/
            btnMultiply.Click += delegate {
                mathOperation = MATH_OPERATION.MULTIPLY;
                saveNumberToMemory(textDisplay);
                clearDisplay(textDisplay);
            };

            /* Divide Button 
             * Event for when the divide button is clicked, saves the number into
             memory then clears the screen for the next number to be entered*/
            btnDivide.Click += delegate {
                mathOperation = MATH_OPERATION.DIVIDE;
                saveNumberToMemory(textDisplay);
                clearDisplay(textDisplay);
            };

            /* Power Button 
             * Event for when the power to the N button is clicked, saves the number into
             memory then clears the screen for the next number to be entered*/
            btnPower.Click += delegate {
                mathOperation = MATH_OPERATION.POWER;
                saveNumberToMemory(textDisplay);
                clearDisplay(textDisplay);
            };

            /* Percent Button 
             Prints the current value as a percent (*100)
             */
            btnPercent.Click += delegate {
                string currentValue = getCurrentDisplayedValue(textDisplay.Text);

                if (currentValue != "0") {
                    textDisplay.Text = prettyOutput((decimal.Parse(currentValue) * 100).ToString());
                }
            };

            /* Square Button
             Prints the current value squared*/
            btnSquared.Click += delegate {
                string currentValue = getCurrentDisplayedValue(textDisplay.Text);

                if (currentValue != "0") {
                    textDisplay.Text = prettyOutput((decimal.Parse(currentValue) * decimal.Parse(currentValue)).ToString());
                }
            };

            /* SqrRoot Button 
             Prints the square root of the current value*/
            btnRoot.Click += delegate {
                string currentValue = getCurrentDisplayedValue(textDisplay.Text);
                if (currentValue != "0") {
                    textDisplay.Text = prettyOutput(Math.Sqrt(double.Parse(currentValue)).ToString());
                }
            };

            /* Equals Button
             * Does our calculation in calculate result
             * by passing our first number, second number and the math operation
             *  */
            btnEquals.Click += delegate {
                secondNumber = null;
                saveNumberToMemory(textDisplay);
                //check valid values in first and second number
                if (firstNumber != null && secondNumber != null) {
                    //Check for divide by 0 error
                        textDisplay.Text = prettyOutput(calculateResult((decimal)firstNumber, (decimal)secondNumber, (MATH_OPERATION)mathOperation).ToString());
                        firstNumber = decimal.Parse(textDisplay.Text);
                    
                }
            };


            /* 
             10 > 1
             4 > 0
             0.1 > 0.
             0. > 0
             0
             */
            /* Button Delete 
             Deletes digits from the right, works with negatives and positives*/
            btnDelete.Click += delegate {
                string currentStringVal = getCurrentDisplayedValue(textDisplay.Text);
                if (currentStringVal != "0") {
                    string removedText = currentStringVal.Substring(0, currentStringVal.Length - 1);
                    if (removedText == "") {
                        removedText = "0";
                    }
                    if (textDisplay.Text.Contains("-")) {
                        textDisplay.Text = prettyOutput("-" + removedText);
                    }
                    else {
                        textDisplay.Text = prettyOutput(removedText);
                    }
                }
            };
            
            /* Button Clear 
             * Clears the display and memory for fresh numbers to be imported*/
            btnClear.Click += delegate {
                clearDisplay(textDisplay);
                firstNumber = null;
                secondNumber = null;
            };


            /* Button Decimal
             * Adds our dot to the screen 13.37  */
            btnDecimal.Click += delegate {
                addDecimalToDisplay(textDisplay); 
            };

            /* Button Plus/Minus 
             *Toggles the plus or minus on the display
             */
            btnPlusMinus.Click += delegate {
                toggleNegative(textDisplay);
            };
        }
        
        
        /// <summary>
        /// Calculate Result
        /// </summary>
        /// <param name="firstNumber">The first number used for calculating</param>
        /// <param name="secondNumber">Second number</param>
        /// <param name="mathOperation">Our math operation determines what math to do</param>
        /// <returns>Decimal</returns>
        private decimal calculateResult(decimal firstNumber, decimal secondNumber, MATH_OPERATION mathOperation) {
            //Console.WriteLine(firstNumber + " "+mathOperation+" " + secondNumber);
                switch (mathOperation) {
                case MATH_OPERATION.ADD:
                    return (decimal)firstNumber + (decimal)secondNumber;
                case MATH_OPERATION.SUBTRACT:
                    return (decimal)firstNumber - (decimal)secondNumber;
                case MATH_OPERATION.MULTIPLY:
                    return (decimal)firstNumber * (decimal)secondNumber;
                case MATH_OPERATION.DIVIDE:
                    //Handles divide by 0, good try.
                    if (secondNumber.Equals(0) || secondNumber.Equals(-0)) return 0;
                    else  return (decimal)firstNumber / (decimal)secondNumber;
                case MATH_OPERATION.POWER:
                    return (decimal) Math.Pow((double)firstNumber,(double)secondNumber);
                case MATH_OPERATION.SQRT:
                    return (decimal)Math.Sqrt((double)firstNumber);
                default: return 0;
                
            }

        }

        //saves number to memory depending on which value is null
        private void saveNumberToMemory(TextView display) {
            if(firstNumber == null) {
                firstNumber = decimal.Parse(display.Text);
            }else if (secondNumber == null) {
                secondNumber = decimal.Parse(display.Text);
            }
        }
        //clears the display with a 0 showing
        private void clearDisplay(TextView display) {
            display.Text = "0";
        }

        /*  
            0 > 5
            5 > 50
            0 > 0.
            1 > 1.
        */
        //gets the string value of what the number is.
        //-14.23 > 14.23
        //Used for formating and validation if the user has a 0.
        private string getCurrentDisplayedValue(string currentDisplayVal) {
            if (currentDisplayVal.Contains("-")) {
                return currentDisplayVal.Substring(1, currentDisplayVal.Length - 1);
            }
            else {
                return currentDisplayVal;
            }
        }
        //Cuts the number to a maximum of 12 characters long
        //so the output does not overflow in the application.
        private string prettyOutput(string unfilterOutput) {
            if (unfilterOutput.Length > 11) {
                if (unfilterOutput.Contains("-")) {
                    return unfilterOutput.Substring(0, 11);
                }
                else {
                    return unfilterOutput.Substring(0, 10);
                }
            }else {
                return unfilterOutput;
            }

        }

        //puts our friendly decimal onto the screen if
        //the display does not already have one
        private void addDecimalToDisplay(TextView display) {
            if (display.Text.Contains(".") == false) {
                display.Text += ".";
            }
        }
        //updates the values in the first and second number
        //converts the string display into a decimal number for math
        private void updateValues(string displayNumber) {
            if(firstNumber != 0) {
                firstNumber = decimal.Parse(displayNumber);

            }else {
                secondNumber = decimal.Parse(displayNumber);
            }
        }

        /*
         * Adds the character to the display
         * */
        private void addToCurrentDisplayedValue(TextView display, string val) {
            // 0 > 1, -0 > -1, 5 > 15, -5 > -15
            if (display.Text.Contains("-")) {
                //-0 > -1
                 if (getCurrentDisplayedValue(display.Text) == "0") {
                    display.Text = "-"+val;
                }
                //-1 > -15
                else {
                    display.Text += val;
                }
            }
            else {
                //0 > 1
                if (getCurrentDisplayedValue(display.Text) == "0") {
                    display.Text = val;
                }
                //1 > 15
                else {
                    display.Text += val;
                }
            }
        }
        
        /*
         * Toggles the minus sign on and off
         */
        private void toggleNegative(TextView display) {
            //toggle positive and negative
            if (display.Text.Contains("-") == false) {
                display.Text = "-" + display.Text;
            }
            else {
                display.Text = display.Text.Substring(1, display.Text.Length-1);
            }
        }

    }

}

