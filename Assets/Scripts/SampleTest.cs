<<<<<<< HEAD
﻿using UnityEngine;
using NUnit.Framework;


public class SampleTest {

    private Collector collector;
    private PlayerScore score;
    [SetUp]
    public void SetUp()
    {
        collector = new GameObject().AddComponent<Collector>();
        score = new GameObject().AddComponent<PlayerScore>();
    }
    [TearDown]
    public void TearDown()
    {
        collector = null;
        score = null;
    }

    //test for collector
    [Test]
    public void test_GetLostHertPoint()
    {
        Assert.AreEqual(collector.GetLostHeartPoint(), 0);
        collector.SetLostHeartPoint(5);
        Assert.AreEqual(collector.GetLostHeartPoint(), 5);
    }

    [Test]
    public void test_LostHeart()
    {
        collector.SetLostHeartPoint(5);
        Assert.AreEqual(collector.IsLostAllHeartPoint(), true);
    }

    [Test]
    public void test_HeartPointLeft()
    {
        collector.SetLostHeartPoint(3);
        Assert.AreEqual(collector.GetHeartPoint(), (5-3));//this  is hard code for testing
    }

    //test for playerscores
    [Test]
    public void test_SetScoresForPlayer()
    {
        Assert.AreEqual(score.GetScores(), 0);
        score.IncreaseScores(10);
        Assert.AreEqual(score.GetScores(), 10);
    }

    [Test]
    public void test_CheckLevelUpdateByScores()
    {
        // bounds checking
        Assert.AreEqual(score.GetLevel(), 0);
        score.IncreaseScores(19);
        Assert.AreEqual(score.GetLevel(), 0);
        score.IncreaseScores(20);
        Assert.AreEqual(score.GetLevel(), 1);//19+20=39
        score.IncreaseScores(21);
        Assert.AreEqual(score.GetLevel(), 3);//19+20+21=60
    }
}
=======
﻿using UnityEngine;
using NUnit.Framework;


public class SampleTest {

    private Collector collector;
    private PlayerScore score;
    [SetUp]
    public void SetUp()
    {
        collector = new GameObject().AddComponent<Collector>();
        score = new GameObject().AddComponent<PlayerScore>();
    }
    [TearDown]
    public void TearDown()
    {
        collector = null;
        score = null;
    }

    //test for collector
    [Test]
    public void test_GetLostHertPoint()
    {
        Assert.AreEqual(collector.GetLostHeartPoint(), 0);
        collector.SetLostHeartPoint(5);
        Assert.AreEqual(collector.GetLostHeartPoint(), 5);
    }

    [Test]
    public void test_LostHeart()
    {
        collector.SetLostHeartPoint(5);
        Assert.AreEqual(collector.IsLostAllHeartPoint(), true);
    }

    [Test]
    public void test_HeartPointLeft()
    {
        collector.SetLostHeartPoint(3);
        Assert.AreEqual(collector.GetHeartPoint(), (5-3));//this  is hard code for testing
    }

    //test for playerscores
    [Test]
    public void test_SetScoresForPlayer()
    {
        Assert.AreEqual(score.GetScores(), 0);
        score.IncreaseScores(10);
        Assert.AreEqual(score.GetScores(), 10);
    }

    [Test]
    public void test_CheckLevelUpdateByScores()
    {
        // bounds checking
        Assert.AreEqual(score.GetLevel(), 0);
        score.IncreaseScores(19);
        Assert.AreEqual(score.GetLevel(), 0);
        score.IncreaseScores(20);
        Assert.AreEqual(score.GetLevel(), 1);//19+20=39
        score.IncreaseScores(21);
        Assert.AreEqual(score.GetLevel(), 3);//19+20+21=60
    }
}
>>>>>>> Bin_Jiang
