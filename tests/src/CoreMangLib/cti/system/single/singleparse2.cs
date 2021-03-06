using System;
using System.Globalization;
/// <summary>
/// Parse(System.String,System.Globalization.NumberStyles)
/// </summary>
public class SingleParse2
{
    #region Public Methods
    public bool RunTests()
    {
        bool retVal = true;

        TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
        retVal = PosTest2() && retVal;
        retVal = PosTest3() && retVal;
        retVal = PosTest4() && retVal;
        retVal = PosTest5() && retVal;
        retVal = PosTest6() && retVal;
        retVal = PosTest7() && retVal;
        TestLibrary.TestFramework.LogInformation("[Negtive]");
        retVal = NegTest1() && retVal;
        retVal = NegTest2() && retVal;
        retVal = NegTest3() && retVal;
        retVal = NegTest4() && retVal;
        retVal = NegTest5() && retVal;
        retVal = NegTest6() && retVal;
        retVal = NegTest7() && retVal;
        return retVal;
    }

    #region Positive Test Cases
    public bool PosTest1()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest1: Check a string which is converted by a random single.");

        try
        {
            Single i1 = TestLibrary.Generator.GetSingle();
            string testValue = i1.ToString("G9");
            retVal = VerifyHelper(i1, testValue, NumberStyles.Float | NumberStyles.AllowCurrencySymbol, "001.1") && retVal;
            retVal = VerifyHelper(i1, testValue, NumberStyles.Float | NumberStyles.AllowDecimalPoint, "001.2") && retVal;
            retVal = VerifyHelper(i1, testValue, NumberStyles.Float | NumberStyles.AllowExponent, "001.3") && retVal;
            retVal = VerifyHelper(i1, testValue, NumberStyles.Float | NumberStyles.AllowLeadingSign, "001.4") && retVal;
            retVal = VerifyHelper(i1, testValue, NumberStyles.Float | NumberStyles.AllowLeadingWhite, "001.5") && retVal;
            retVal = VerifyHelper(i1, testValue, NumberStyles.Float | NumberStyles.AllowParentheses, "001.6") && retVal;
            retVal = VerifyHelper(i1, testValue, NumberStyles.Float | NumberStyles.AllowThousands, "001.7") && retVal;
            retVal = VerifyHelper(i1, testValue, NumberStyles.Float | NumberStyles.AllowTrailingSign, "001.8") && retVal;
            retVal = VerifyHelper(i1, testValue, NumberStyles.Float | NumberStyles.AllowTrailingWhite, "001.9") && retVal;
            retVal = VerifyHelper(i1, testValue, NumberStyles.Float | NumberStyles.Any, "001.10") && retVal;
            retVal = VerifyHelper(i1, testValue, NumberStyles.Float | NumberStyles.Currency, "001.11") && retVal;
            retVal = VerifyHelper(i1, testValue, NumberStyles.Float | NumberStyles.Integer, "001.12") && retVal;
            retVal = VerifyHelper(i1, testValue, NumberStyles.Float | NumberStyles.None, "001.13") && retVal;
            retVal = VerifyHelper(i1, testValue, NumberStyles.Number, "001.14") && retVal;

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("001.2", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }

    public bool PosTest2()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest2: check a string  which is  not a number .");

        try
        {
            Single i1 = Single.NaN;
            string testValue = i1.ToString();
            Single actualValue = Single.Parse(testValue, NumberStyles.Float | NumberStyles.AllowThousands);
            if (!Single.IsNaN(actualValue))
            {
                TestLibrary.TestFramework.LogError("002.1", "Parse  return failed. ");
                retVal = false;
            }
            i1 = Single.NegativeInfinity;
            testValue = i1.ToString();
            actualValue = Single.Parse(testValue, NumberStyles.Float | NumberStyles.AllowThousands);
            if (!Single.IsNegativeInfinity(actualValue))
            {
                TestLibrary.TestFramework.LogError("002.2", "Parse  return failed.");
                retVal = false;
            }
            i1 = Single.PositiveInfinity;
            testValue = i1.ToString();
            actualValue = Single.Parse(testValue, NumberStyles.Float | NumberStyles.AllowThousands);
            if (!Single.IsPositiveInfinity(actualValue))
            {
                TestLibrary.TestFramework.LogError("002.3", "Parse  return failed. ");
                retVal = false;
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("002.4", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    public bool PosTest3()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest3: Check a string which is converted by -123,456,789.");

        try
        {
            Single i1 = -123456789;
            CultureInfo myCulture = CultureInfo.CurrentCulture;
            string mySeparator = myCulture.NumberFormat.CurrencyGroupSeparator;
            string testValue = "-123" + mySeparator + "456" + mySeparator + "789";
            if (Single.Parse(testValue, NumberStyles.Float | NumberStyles.AllowThousands) != i1)
            {
                TestLibrary.TestFramework.LogError("003.1", "Parse  return failed. ");
                retVal = false;
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("003.2", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    public bool PosTest4()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest4: Check a string which is converted by 123.45e+6.");

        try
        {
            Single i1 = (Single)123.45e+6;
            string testValue = "123" + CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + "45e+6";
            Single actualValue = Single.Parse(testValue, NumberStyles.Float | NumberStyles.AllowThousands);
            if (actualValue != i1)
            {
                TestLibrary.TestFramework.LogError("004.1", "Parse  return failed. ");
                retVal = false;
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("004.2", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    public bool PosTest5()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest5: Check a string which is converted by .123.");

        try
        {
            Single i1 = (Single)(.123);
            string testValue = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + "123";
            Single actualValue = Single.Parse(testValue, NumberStyles.Float | NumberStyles.AllowThousands);
            if (actualValue != i1)
            {
                TestLibrary.TestFramework.LogError("005.1", "Parse  return failed. ");
                retVal = false;
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("005.2", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    public bool PosTest6()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest6: Check a string which is converted by  blank blank blank 123.");

        try
        {
            Single i1 = (Single)(123);
            string testValue = "   123";
            Single actualValue = Single.Parse(testValue, NumberStyles.Float | NumberStyles.AllowThousands);
            if (actualValue != i1)
            {
                TestLibrary.TestFramework.LogError("006.1", "Parse  return failed. ");
                retVal = false;
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("006.2", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    public bool PosTest7()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest7: Check a string which is converted by  +123.");

        try
        {
            Single i1 = (Single)(+123);
            string testValue = "+123";
            Single actualValue = Single.Parse(testValue, NumberStyles.Float | NumberStyles.AllowThousands);
            if (actualValue != i1)
            {
                TestLibrary.TestFramework.LogError("007.1", "Parse  return failed. ");
                retVal = false;
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("007.2", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    public bool NegTest1()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest1: s is a null reference.");

        try
        {

            string testValue = null;
            Single actualValue = Single.Parse(testValue, NumberStyles.Float | NumberStyles.AllowThousands);
            TestLibrary.TestFramework.LogError("101.1", "Parse  return failed. ");
            retVal = false;

        }
        catch (ArgumentNullException)
        {

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("101.2", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    public bool NegTest2()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest2: s is not a number in a valid format.");

        try
        {

            string testValue = "ADSD";
            Single actualValue = Single.Parse(testValue, NumberStyles.Float | NumberStyles.AllowCurrencySymbol);
            TestLibrary.TestFramework.LogError("102.1", "Parse  return failed. ");
            retVal = false;

        }
        catch (FormatException)
        {

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("102.2", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    public bool NegTest3()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest3: s represents a number less than MinValue.");

        try
        {

            string testValue = "-3"+ CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + "40282346638528859e+39";
            Single actualValue = Single.Parse(testValue, NumberStyles.Float | NumberStyles.AllowThousands);
            TestLibrary.TestFramework.LogError("103.1", "Parse  return failed. ");
            retVal = false;

        }
        catch (OverflowException)
        {

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("103.2", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    public bool NegTest4()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest4: s represents a number  greater than MaxValue.");

        try
        {

            string testValue = "3" + CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + "40282346638528859e+39"; ;
            Single actualValue = Single.Parse(testValue, NumberStyles.Float | NumberStyles.AllowThousands);
            TestLibrary.TestFramework.LogError("104.1", "Parse  return failed. ");
            retVal = false;

        }
        catch (OverflowException)
        {

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("104.2", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    public bool NegTest5()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest5: an error NumberStyles.");

        try
        {
            Single i1 = TestLibrary.Generator.GetSingle();
            string testValue = i1.ToString("G9");
            retVal = VerifyNegTiveHelper(i1, testValue, NumberStyles.AllowCurrencySymbol, "001.1") && retVal;
            retVal = VerifyNegTiveHelper(i1, testValue, NumberStyles.AllowExponent, "105.2") && retVal;
            retVal = VerifyNegTiveHelper(i1, testValue, NumberStyles.AllowLeadingSign, "105.3") && retVal;
            retVal = VerifyNegTiveHelper(i1, testValue, NumberStyles.AllowLeadingWhite, "105.4") && retVal;
            retVal = VerifyNegTiveHelper(i1, testValue, NumberStyles.AllowParentheses, "105.5") && retVal;
            retVal = VerifyNegTiveHelper(i1, testValue, NumberStyles.AllowThousands, "105.6") && retVal;
            retVal = VerifyNegTiveHelper(i1, testValue, NumberStyles.AllowTrailingSign, "105.7") && retVal;
            retVal = VerifyNegTiveHelper(i1, testValue, NumberStyles.AllowTrailingWhite, "105.8") && retVal;
            retVal = VerifyNegTiveHelper(i1, testValue, NumberStyles.Integer, "105.9") && retVal;
            retVal = VerifyNegTiveHelper(i1, testValue, NumberStyles.None, "105.10") && retVal;
        }
        catch (OverflowException)
        {

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("105.2", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }


    public bool NegTest6()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest6: style is the AllowHexSpecifier value.");

        try
        {
            Single i1 = TestLibrary.Generator.GetSingle();
            string testValue = i1.ToString("G9");
            retVal = VerifyNegTiveHelper1(i1, testValue, NumberStyles.AllowHexSpecifier, "006.1") && retVal;
            retVal = VerifyNegTiveHelper1(i1, testValue, NumberStyles.HexNumber, "106.2") && retVal;
        }

        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("106.0", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }

    public bool NegTest7()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest7: style is not a NumberStyles value.");

        try
        {
            Single i1 = TestLibrary.Generator.GetSingle();
            string testValue = i1.ToString("G9");
            retVal = VerifyNegTiveHelper1(i1, testValue, (NumberStyles)99999, "106.3") && retVal;
        }

        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("106.0", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    #endregion

    #endregion

    public static int Main()
    {
        SingleParse2 test = new SingleParse2();

        TestLibrary.TestFramework.BeginTestCase("SingleParse2");

        if (test.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }
    #region private method
    private bool VerifyHelper(Single expectValue, string testValue, NumberStyles myNumberStyles, string errorno)
    {
        bool retVal = true;
        try
        {
            Single actualValue = Single.Parse(testValue, myNumberStyles);
            if (actualValue != expectValue)
            {
                TestLibrary.TestFramework.LogError(errorno, "Parse  return failed. ");
                retVal = false;
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError(errorno + ".0", "Unexpected exception: " + e);
            retVal = false;
        }
        return retVal;
    }
    private bool VerifyNegTiveHelper(Single expectValue, string testValue, NumberStyles myNumberStyles, string errorno)
    {
        bool retVal = true;
        try
        {
            Single actualValue = Single.Parse(testValue, myNumberStyles);
            TestLibrary.TestFramework.LogError(errorno, "Parse  return failed. ");
            retVal = false;
        }
        catch (FormatException)
        {

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError(errorno + ".0", "Unexpected exception: " + e);
            retVal = false;
        }
        return retVal;
    }
    private bool VerifyNegTiveHelper1(Single expectValue, string testValue, NumberStyles myNumberStyles, string errorno)
    {
        bool retVal = true;
        try
        {
            Single actualValue = Single.Parse(testValue, myNumberStyles);
            TestLibrary.TestFramework.LogError(errorno, "Parse  return failed. ");
            retVal = false;
        }
        catch (ArgumentException)
        {

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError(errorno + ".0", "Unexpected exception: " + e);
            retVal = false;
        }
        return retVal;
    }
    #endregion

}
