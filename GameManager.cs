using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

	//Text objekten till svaren och matte frågan.
    public TextMeshProUGUI answerOne,answerTwo,answerThree,answerFour;
    public TextMeshProUGUI question;

	// Första variabelen att använda.
    public int firstValue;
	// Andra variabelen att använda.
    public int secondValue;
	// Svaret av de två variablerna.
    public int answerValue;
	// Vilken av knapparna som innehåller svaret.
    public int answerID;

	// Sparar hur många antal rätt eller fel du har.
	public float prefsStorer;
	// En sifra mellan 0 - 1, används för att slumpvis välja variablar och operator.
    public float randomValue;
	// En sifra mellan 0 - 1, används för att slumpvis välja variablar och operator.
    public float randomValueForOperator;
	// En sifra mellan 0 - 1, används för att slumpvis välja variablar och operator.
    public float randomValueForAnswers;
	// En sifra mellan 0 - 1, används för att slumpvis välja variablar och operator. Välj valutor för procenten i editior.
	public float[] precentagesForTheValues;

	// En slider som vissar hur många rätt eller fel du har haft.
    public Slider progressBar;

	// Use this for initialization
	void Start () {
		// Gör säkert att svaret är 0 inan variablerna och operatorn är valda.
        answerValue = 0;
		// Gör denna float till en siffra mellan 0 - 1.
        randomValue = Random.value;
		// Gör denna float till en siffra mellan 0 - 1.
        randomValueForOperator = Random.value;
		// Gör denna float till en siffra mellan 0 - 1.
        randomValueForAnswers = Random.value;
		// Hämtar hur många rätt du har efter varje fråga.
        prefsStorer = PlayerPrefs.GetFloat("CorrectAnswers");
    }
	
	// Update is called once per frame
	void Update ()
    {
		// Gör slidern till samma float som prefsStorer men gör den till decimaler då sliders operar i 0-1.
        progressBar.value = prefsStorer / 10f;
		// Gör så att CorrectAnswers är samma sak som prefsStorer.
        PlayerPrefs.SetFloat("CorrectAnswers", prefsStorer);


		// Slumpvisst väljer de två siffrorna.
		if(randomValue > precentagesForTheValues[0] && randomValue < precentagesForTheValues[1])
        {
            firstValue = 50;
            secondValue = 5;
        }
		else if (randomValue >= precentagesForTheValues[1] && randomValue < precentagesForTheValues[2])
        {
            firstValue = 4;
            secondValue = 2;
        }
		else if (randomValue >= precentagesForTheValues[2] && randomValue < precentagesForTheValues[3])
        {
            firstValue = 6;
            secondValue = 3;
        }
		else if (randomValue >= precentagesForTheValues[3] && randomValue < precentagesForTheValues[4])
        {
            firstValue = 15;
            secondValue = 3;
        }
		else if (randomValue >= precentagesForTheValues[4] && randomValue < precentagesForTheValues[5])
        {
            firstValue = 8;
            secondValue = 8;
        }
		else if (randomValue >= precentagesForTheValues[5] && randomValue < precentagesForTheValues[6])
        {
            firstValue = 10;
            secondValue = 5;
        }
		else if (randomValue >= precentagesForTheValues[6] && randomValue < precentagesForTheValues[7])
        {
            firstValue = 20;
            secondValue = 10;
        }
		else if (randomValue >= precentagesForTheValues[7] && randomValue < precentagesForTheValues[8])
        {
            firstValue = 12;
            secondValue = 6;
        }
		else if (randomValue >= precentagesForTheValues[8] && randomValue < precentagesForTheValues[9])
        {
            firstValue = 16;
            secondValue = 8;
        }
		else if (randomValue >= precentagesForTheValues[9] && randomValue <= precentagesForTheValues[10])
        {
            firstValue = 14;
            secondValue = 2;
        }

		// Slumpvist väljer operatorn.
        if(randomValueForOperator >= 0f && randomValueForOperator < 0.25f)
        {
            answerValue = firstValue + secondValue;
            question.text = firstValue + " " + "+" + " "  + secondValue;
        }
        else if(randomValueForOperator >= 0.25f && randomValueForOperator < 0.5f)
        {
            answerValue = firstValue - secondValue;
            question.text = firstValue + " " + "-" + " " + secondValue;
        }
        else if (randomValueForOperator >= 0.5f && randomValueForOperator < 0.75f)
        {
            answerValue = firstValue * secondValue;
            question.text = firstValue + " " + "*" + " " + secondValue;
        }
        else if (randomValueForOperator >= 0.75f && randomValueForOperator <= 1f)
        {
            answerValue = firstValue / secondValue;
            question.text = firstValue + " " + "/" + " " + secondValue;
        }

		// Slumpvist väljer vilken knap som ska innehålla svaret, och vilka som inte ska ha.
        if(randomValueForAnswers >= 0f && randomValueForAnswers < 0.25f)
        {
            int firstRandom = firstValue + 9;
            int SecondRandom = firstValue * 9;
            int ThreeRandom = firstValue - 9;

            answerOne.text = answerValue.ToString();
            answerTwo.text = firstRandom.ToString();
            answerThree.text = SecondRandom.ToString();
            answerFour.text = ThreeRandom.ToString();

			// Gör knapp ett till rätt svar.
            answerID = 1;
        }
		// Slumpvist väljer vilken knap som ska innehålla svaret, och vilka som inte ska ha.
        else if (randomValueForAnswers >= 0.25f && randomValueForAnswers < 0.5f)
        {
            int firstRandom = firstValue + 9;
            int SecondRandom = firstValue * 9;
            int ThreeRandom = firstValue - 9;

            answerOne.text = firstRandom.ToString();
            answerTwo.text = answerValue.ToString();
            answerThree.text = SecondRandom.ToString();
            answerFour.text = ThreeRandom.ToString();

			// Gör knapp Två till rätt svar.
            answerID = 2;
        }
		// Slumpvist väljer vilken knap som ska innehålla svaret, och vilka som inte ska ha.
        else if (randomValueForAnswers >= 0.5f && randomValueForAnswers < 0.75f)
        {
            int firstRandom = firstValue + 9;
            int SecondRandom = firstValue * 9;
            int ThreeRandom = firstValue - 9;

            answerOne.text = firstRandom.ToString();
            answerTwo.text = SecondRandom.ToString();
            answerThree.text = answerValue.ToString();
            answerFour.text = ThreeRandom.ToString();

			// Gör knapp Tre till rätt svar.
            answerID = 3;
        }
		// Slumpvist väljer vilken knap som ska innehålla svaret, och vilka som inte ska ha.
        else if (randomValueForAnswers >= 0.75f && randomValueForAnswers <= 1f)
        {
            int firstRandom = firstValue + 9;
            int SecondRandom = firstValue * 9;
            int ThreeRandom = firstValue - 9;

            answerOne.text = firstRandom.ToString();
            answerTwo.text = SecondRandom.ToString();
            answerThree.text = ThreeRandom.ToString();
            answerFour.text = answerValue.ToString();

			// Gör knapp fyra till rätt svar.
            answerID = 4;
        }

		if (progressBar.value >= 1)   
		{
			// Ifall du har fått rätt på alla frågor.
			Debug.Log ("Game is Finished");
		}
			
    }

	// Ifall knap ett är fel eller rätt, koppa denna till knap ett.
    public void FirstButton()
    {
        if(answerID == 1)
        {
            Start();
            prefsStorer++;
        }
		else
		{
			Start ();
			prefsStorer--;
		}
    }

	// Ifall knap ett är fel eller rätt, koppa denna till knap Två.
    public void SecondButton()
    {
        if (answerID == 2)
        {
            Start();
            prefsStorer++;
        }
		else
		{
			Start ();
			prefsStorer--;
		}
    }

	// Ifall knap ett är fel eller rätt, koppa denna till knap Tre.
    public void ThirdButton()
    {
        if (answerID == 3)
        {
            Start();
            prefsStorer++;
        }
		else
		{
			Start ();
			prefsStorer--;
		}
    }

	// Ifall knap ett är fel eller rätt, koppa denna till knap Fyra.
    public void FourthButton()
    {
        if (answerID == 4)
        {
            Start();
            prefsStorer++;
        }
		else
		{
			Start ();
			prefsStorer--;
		}
    }
}
