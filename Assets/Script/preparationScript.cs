using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PrepStage
{
    startMode,
    medicineChoice,
    creationMode,
    finishedProduct
}

public class preparationScript : MonoBehaviour {
    public static PrepStage prepStage;

    public GameObject _startMode;
    public GameObject _medicineChoice;
    public GameObject _creationMode;
    public GameObject _finishedProduct;

    void Awake()
    {
        _startMode = GameObject.FindGameObjectWithTag("startPrep");
        _medicineChoice = GameObject.FindGameObjectWithTag("medicineChoice");
        _creationMode = GameObject.FindGameObjectWithTag("creationMode");
        _finishedProduct = GameObject.FindGameObjectWithTag("productDetails");
    }

    // Use this for initialization
    void Start () {
        prepStage = PrepStage.startMode;
	}
	
	// Update is called once per frame
	void Update () {
        if (prepStage == PrepStage.startMode)
        { 
            _startMode.SetActive(true);
            _medicineChoice.SetActive(false);
            _creationMode.SetActive(false);
            _finishedProduct.SetActive(false);
        }

        if (prepStage == PrepStage.medicineChoice)
        {
            _startMode.SetActive(false);
            _medicineChoice.SetActive(true);
            _creationMode.SetActive(false);
            _finishedProduct.SetActive(false);
        }

        if (prepStage == PrepStage.creationMode)
        {
            _startMode.SetActive(false);
            _medicineChoice.SetActive(false);
            _creationMode.SetActive(true);
            _finishedProduct.SetActive(false);
        }

        if (prepStage == PrepStage.finishedProduct)
        {
            _startMode.SetActive(false);
            _medicineChoice.SetActive(false);
            _creationMode.SetActive(false);
            _finishedProduct.SetActive(true);
        }
    }

    public void next()
    {
        if (prepStage == PrepStage.startMode)
        {
            prepStage = PrepStage.medicineChoice;
        }

        else if (prepStage == PrepStage.medicineChoice)
        {
            prepStage = PrepStage.creationMode;
        }

        else if (prepStage == PrepStage.creationMode)
        {
            prepStage = PrepStage.finishedProduct;
        }

        else if (prepStage == PrepStage.finishedProduct)
        {
            prepStage = PrepStage.startMode;
        }
    }

    public void back()
    {
        if (prepStage == PrepStage.medicineChoice)
        {
            prepStage = PrepStage.startMode;
        }

        else if (prepStage == PrepStage.creationMode)
        {
            prepStage = PrepStage.medicineChoice;
        }

        else if (prepStage == PrepStage.finishedProduct)
        {
            prepStage = PrepStage.creationMode;
        }
    }
}
