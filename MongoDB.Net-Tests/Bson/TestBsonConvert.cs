/*
 * User: scorder
 * Date: 7/15/2009
 */

using System;
using NUnit.Framework;

using MongoDB.Driver;

namespace MongoDB.Driver.Bson
{
	[TestFixture]
	public class TestBsonConvert
	{
		[Test]
		public void TestFromDocument(){
			Document doc = new Document();
			doc.Add("string", "test");
			doc.Add("int", 1);
            doc.Add("long", 852009);
			BsonDocument bdoc = BsonConvert.From(doc);
			Assert.AreEqual(3,bdoc.Count);
			
			/*doc.Add("date", DateTime.MinValue);  
			Assert.Throws<ArgumentOutOfRangeException>(
				delegate {BsonConvert.From(doc);});*/ //Not in nUnit 2.4.
			

		}
		[Test]
		public void TestFromInt(){
			BsonType t = BsonConvert.From(1);
			Assert.AreEqual(typeof(BsonInteger),t.GetType());
			Assert.AreEqual(1, ((BsonInteger)t).Val);
		}

        [Test]
        public void TestFromLong(){
            long comparer = 852009;
            BsonType l = BsonConvert.From(comparer);
            Assert.AreEqual(typeof(BsonLong), l.GetType());
            Assert.AreEqual(comparer, ((BsonLong)l).Val);
        }
		
		[Test]
		public void TestCreate(){
			BsonString bs = (BsonString)BsonConvert.Create(BsonDataType.String);
			Assert.IsNotNull(bs);
			
			BsonDocument bd = (BsonDocument)BsonConvert.Create(BsonDataType.Obj);
			Assert.IsNotNull(bd);
		}
	}
}