using System;
using System.Linq;
using System.Numerics;
using CGScopeChallengeCode;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting
{
    [TestClass]
    public class ChallengeUnitTests
    {
        [TestMethod]
        public void Test_RunningMedianWithArrayOfSize10AndWrongArraySizeInput_ShouldThrowAnException()
        {
            BigInteger[] integers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            RunningMedian runningMedian = new RunningMedian();

            Assert.ThrowsException<Exception>(() => runningMedian.GetMedians(integers, 11));

        }

        [TestMethod]
        public void Test_RunningMedianWithArrayOfSize10AnInputSize10_ShouldReturnArrayOfRunningMedian()
        {
            BigInteger[] integers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            double[] mediansResultOutput = { 1.0, 1.5, 2.0, 2.5, 3.0, 3.5, 4.0, 4.5, 5.0, 5.5 };

            RunningMedian runningMedian = new RunningMedian();

            var medians = runningMedian.GetMedians(integers, 10);

            for (int i = 0; i < mediansResultOutput.Length; i++)
            {
                Assert.AreEqual(mediansResultOutput[i], medians[i]);
            }
        }




        [TestMethod]
        public void Test_MouseVsMouse_WithTwoSentencesAndWrongInputSize_ShouldThrowAnException()
        {
            var sentences = new[]
            {"A mouse usually likes cheese",
                "A modern mouse will probably use a laser instead of a ball." };

            MouseVsMouse mouseVsMouse = new MouseVsMouse();

            Assert.ThrowsException<Exception>(
                () => mouseVsMouse.DistinguishSentences(3, sentences));
        }

        [TestMethod]
        public void Test_MouseVsMouse_WithTwoSentences_ShouldReturnAnimalAndComputerMouse()
        {
            var sentences = new[]
                {"A mouse usually likes cheese",
                "A modern mouse will probably use a laser instead of a ball." };

            MouseVsMouse mouseVsMouse = new MouseVsMouse();

            var mouseMeanings = mouseVsMouse.DistinguishSentences(2, sentences);

            Assert.AreEqual(MouseMeaning.Animal, mouseMeanings[0]);
            Assert.AreEqual(MouseMeaning.ComputerMouse, mouseMeanings[1]);

        }
        [TestMethod]
        public void Test_MouseVsMouse_With10Sentences_ShouldReturnFirstFiveAnimalAndLastFiveMouseComputer()
        {

            var sentences = new[]
            {
                "The complete mouse reference genome was sequenced in 2002",
                "Tail length varies according to the environmental temperature of the mouse during postnatal development.",
                "The average sleep time of a captive house mouse is reported to be 12.5 hours per day.",
                "Both evolutionary and behavioral consequences result from the polygamous nature of the house mouse. ",
                "The best known mouse species is the common house mouse.",
                "Choose from wireless & USB mouse options as well as ergonomic & gaming mice.",
                "The Razer DeathAdder Chroma is equipped with a 10,000dpi optical sensor, capable of mouse movement speeds of up to 300 inches per second.",
                "Use a light touch when clicking a mouse button.",
                "Move the mouse by pivoting your arm at your elbow.",
                "Turn your mobile phone or tablet into a set of wireless mouse and keyboard. "
            };

            MouseVsMouse mouseVsMouse = new MouseVsMouse();

            var mouseMeanings = mouseVsMouse.DistinguishSentences(10, sentences).ToList();

            mouseMeanings.GetRange(0, 4).ForEach(mouseMeaning =>
            {
                Assert.AreEqual(MouseMeaning.Animal, mouseMeaning);
            });
            mouseMeanings.GetRange(5, 4).ForEach(mouseMeaning =>
            {
                Assert.AreEqual(MouseMeaning.ComputerMouse, mouseMeaning);
            });

        }


    }
}
