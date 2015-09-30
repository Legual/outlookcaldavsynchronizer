﻿using System;
using System.IO;
using CalDavSynchronizer.DDayICalWorkaround;
using DDay.iCal;
using DDay.iCal.Serialization.iCalendar;
using NUnit.Framework;

namespace CalDavSynchronizer.UnitTest.DDayICalWorkaround
{
  [TestFixture]
  public class CalendarDataPreprocessorFixture
  {
    [Test]
    public void FixTimeZoneComponentOrder_TestRealEvent ()
    {
      string input = @"BEGIN:VCALENDAR
PRODID:-//bitfire web engineering//DAVdroid 0.8.4.1 (ical4j 2.0-beta1)//EN
VERSION:2.0
BEGIN:VTIMEZONE
TZID:Europe/Vienna
TZURL:http://tzurl.org/zoneinfo/Europe/Vienna
X-LIC-LOCATION:Europe/Vienna
BEGIN:DAYLIGHT
TZOFFSETFROM:+0100
TZOFFSETTO:+0200
TZNAME:CEST
DTSTART:19810329T020000
RRULE:FREQ=YEARLY;BYMONTH=3;BYDAY=-1SU
END:DAYLIGHT
BEGIN:STANDARD
TZOFFSETFROM:+0200
TZOFFSETTO:+0100
TZNAME:CET
DTSTART:19961027T030000
RRULE:FREQ=YEARLY;BYMONTH=10;BYDAY=-1SU
END:STANDARD
BEGIN:STANDARD
TZOFFSETFROM:+010521
TZOFFSETTO:+0100
TZNAME:CET
DTSTART:18930401T000000
RDATE:18930401T000000
END:STANDARD
BEGIN:DAYLIGHT
TZOFFSETFROM:+0100
TZOFFSETTO:+0200
TZNAME:CEST
DTSTART:19160501T000000
RDATE:19160501T000000
RDATE:19170416T030000
RDATE:19180415T030000
RDATE:19200405T030000
RDATE:19400401T030000
RDATE:19430329T030000
RDATE:19440403T030000
RDATE:19450402T030000
RDATE:19460414T030000
RDATE:19470406T030000
RDATE:19480418T030000
RDATE:19800406T000000
END:DAYLIGHT
BEGIN:STANDARD
TZOFFSETFROM:+0200
TZOFFSETTO:+0100
TZNAME:CET
DTSTART:19161001T010000
RDATE:19161001T010000
RDATE:19170917T030000
RDATE:19180916T030000
RDATE:19200913T030000
RDATE:19421102T030000
RDATE:19431004T030000
RDATE:19441002T030000
RDATE:19450412T030000
RDATE:19461006T030000
RDATE:19471005T030000
RDATE:19481003T030000
RDATE:19800928T000000
RDATE:19810927T030000
RDATE:19820926T030000
RDATE:19830925T030000
RDATE:19840930T030000
RDATE:19850929T030000
RDATE:19860928T030000
RDATE:19870927T030000
RDATE:19880925T030000
RDATE:19890924T030000
RDATE:19900930T030000
RDATE:19910929T030000
RDATE:19920927T030000
RDATE:19930926T030000
RDATE:19940925T030000
RDATE:19950924T030000
END:STANDARD
BEGIN:STANDARD
TZOFFSETFROM:+0100
TZOFFSETTO:+0100
TZNAME:CET
DTSTART:19200101T000000
RDATE:19200101T000000
RDATE:19460101T000000
RDATE:19810101T000000
END:STANDARD
END:VTIMEZONE
BEGIN:VEVENT
DTSTAMP:20150925T061111Z
UID:566745d3-04ed-497a-9d1b-47db1bb12629
DTSTART;TZID=Europe/Vienna:20151125T133500
DTEND;TZID=Europe/Vienna:20151125T151500
SUMMARY:EZG-ILV  EDV_F1.03 - MGS-1
LOCATION:EDV_F1.03
DESCRIPTION:EZG-ILV\nHesinaGe\nMGS-1  \nEDV_F1.03
CLASS:PUBLIC
LAST-MODIFIED:20150927T175324Z
TRANSP:OPAQUE
SEQUENCE:2
END:VEVENT
END:VCALENDAR
";

      string expected = @"BEGIN:VCALENDAR
PRODID:-//bitfire web engineering//DAVdroid 0.8.4.1 (ical4j 2.0-beta1)//EN
VERSION:2.0
BEGIN:VTIMEZONE
TZID:Europe/Vienna
TZURL:http://tzurl.org/zoneinfo/Europe/Vienna
X-LIC-LOCATION:Europe/Vienna
BEGIN:STANDARD
TZOFFSETFROM:+010521
TZOFFSETTO:+0100
TZNAME:CET
DTSTART:18930401T000000
RDATE:18930401T000000
END:STANDARD
BEGIN:DAYLIGHT
TZOFFSETFROM:+0100
TZOFFSETTO:+0200
TZNAME:CEST
DTSTART:19160501T000000
RDATE:19160501T000000
RDATE:19170416T030000
RDATE:19180415T030000
RDATE:19200405T030000
RDATE:19400401T030000
RDATE:19430329T030000
RDATE:19440403T030000
RDATE:19450402T030000
RDATE:19460414T030000
RDATE:19470406T030000
RDATE:19480418T030000
RDATE:19800406T000000
END:DAYLIGHT
BEGIN:STANDARD
TZOFFSETFROM:+0200
TZOFFSETTO:+0100
TZNAME:CET
DTSTART:19161001T010000
RDATE:19161001T010000
RDATE:19170917T030000
RDATE:19180916T030000
RDATE:19200913T030000
RDATE:19421102T030000
RDATE:19431004T030000
RDATE:19441002T030000
RDATE:19450412T030000
RDATE:19461006T030000
RDATE:19471005T030000
RDATE:19481003T030000
RDATE:19800928T000000
RDATE:19810927T030000
RDATE:19820926T030000
RDATE:19830925T030000
RDATE:19840930T030000
RDATE:19850929T030000
RDATE:19860928T030000
RDATE:19870927T030000
RDATE:19880925T030000
RDATE:19890924T030000
RDATE:19900930T030000
RDATE:19910929T030000
RDATE:19920927T030000
RDATE:19930926T030000
RDATE:19940925T030000
RDATE:19950924T030000
END:STANDARD
BEGIN:STANDARD
TZOFFSETFROM:+0100
TZOFFSETTO:+0100
TZNAME:CET
DTSTART:19200101T000000
RDATE:19200101T000000
RDATE:19460101T000000
RDATE:19810101T000000
END:STANDARD
BEGIN:DAYLIGHT
TZOFFSETFROM:+0100
TZOFFSETTO:+0200
TZNAME:CEST
DTSTART:19810329T020000
RRULE:FREQ=YEARLY;BYMONTH=3;BYDAY=-1SU
END:DAYLIGHT
BEGIN:STANDARD
TZOFFSETFROM:+0200
TZOFFSETTO:+0100
TZNAME:CET
DTSTART:19961027T030000
RRULE:FREQ=YEARLY;BYMONTH=10;BYDAY=-1SU
END:STANDARD
END:VTIMEZONE
BEGIN:VEVENT
DTSTAMP:20150925T061111Z
UID:566745d3-04ed-497a-9d1b-47db1bb12629
DTSTART;TZID=Europe/Vienna:20151125T133500
DTEND;TZID=Europe/Vienna:20151125T151500
SUMMARY:EZG-ILV  EDV_F1.03 - MGS-1
LOCATION:EDV_F1.03
DESCRIPTION:EZG-ILV\nHesinaGe\nMGS-1  \nEDV_F1.03
CLASS:PUBLIC
LAST-MODIFIED:20150927T175324Z
TRANSP:OPAQUE
SEQUENCE:2
END:VEVENT
END:VCALENDAR
";

      var processed = CalendarDataPreprocessor.FixTimeZoneComponentOrderNoThrow (input);

      Assert.That (processed, Is.EqualTo (expected));
      AssertCanDeserialize (processed);
    }


    [Test]
    public void FixTimeZoneComponentOrder_EventHasNoTimeZones_DoesntChangeEvent ()
    {
      string input = @"BEGIN:VCALENDAR
PRODID:-//bitfire web engineering//DAVdroid 0.8.4.1 (ical4j 2.0-beta1)//EN
VERSION:2.0
BEGIN:VEVENT
DTSTAMP:20150925T061111Z
UID:566745d3-04ed-497a-9d1b-47db1bb12629
DTSTART;TZID=Europe/Vienna:20151125T133500
DTEND;TZID=Europe/Vienna:20151125T151500
SUMMARY:EZG-ILV  EDV_F1.03 - MGS-1
LOCATION:EDV_F1.03
DESCRIPTION:EZG-ILV\nHesinaGe\nMGS-1  \nEDV_F1.03
CLASS:PUBLIC
LAST-MODIFIED:20150927T175324Z
TRANSP:OPAQUE
SEQUENCE:2
END:VEVENT
END:VCALENDAR
";

      var processed = CalendarDataPreprocessor.FixTimeZoneComponentOrderNoThrow (input);

      Assert.That (processed, Is.EqualTo (input));
      AssertCanDeserialize (processed);
    }


    [Test]
    public void FixTimeZoneComponentOrder_StartTimeOfOneComponentIsNotParseable_IgnoresComnponentAndAddsItAfterSortedConmponents ()
    {
      string input = @"BEGIN:VCALENDAR
BEGIN:VTIMEZONE
TZID:Europe/Vienna
X-LIC-LOCATION:Europe/Vienna
BEGIN:STANDARD
TZNAME:CET
DTSTART:19961027T030000
END:STANDARD
BEGIN:DAYLIGHT
TZNAME:CEST
DTSTART:19810329T020000
END:DAYLIGHT
BEGIN:STANDARD
TZNAME:CET
DTSTART:19200101T000000
END:STANDARD
BEGIN:DAYLIGHT
TZNAME:CEST
DTSTART:xxxxxxxxxxxxxxxxxxxxxxx
END:DAYLIGHT
BEGIN:STANDARD
TZNAME:CET
DTSTART:19161001T010000
END:STANDARD
BEGIN:STANDARD
TZNAME:CET
DTSTART:18930401T000000
END:STANDARD
END:VTIMEZONE
BEGIN:VEVENT
SUMMARY:Termin
END:VEVENT
END:VCALENDAR
";

      string expected = @"BEGIN:VCALENDAR
BEGIN:VTIMEZONE
TZID:Europe/Vienna
X-LIC-LOCATION:Europe/Vienna
BEGIN:STANDARD
TZNAME:CET
DTSTART:18930401T000000
END:STANDARD
BEGIN:STANDARD
TZNAME:CET
DTSTART:19161001T010000
END:STANDARD
BEGIN:STANDARD
TZNAME:CET
DTSTART:19200101T000000
END:STANDARD
BEGIN:DAYLIGHT
TZNAME:CEST
DTSTART:19810329T020000
END:DAYLIGHT
BEGIN:STANDARD
TZNAME:CET
DTSTART:19961027T030000
END:STANDARD
BEGIN:DAYLIGHT
TZNAME:CEST
DTSTART:xxxxxxxxxxxxxxxxxxxxxxx
END:DAYLIGHT
END:VTIMEZONE
BEGIN:VEVENT
SUMMARY:Termin
END:VEVENT
END:VCALENDAR
";

      var processed = CalendarDataPreprocessor.FixTimeZoneComponentOrderNoThrow (input);

      Assert.That (processed, Is.EqualTo (expected));
    }

    [Test]
    public void FixTimeZoneComponentOrder_EventHasMultipleTimeZomes ()
    {
      string input = @"BEGIN:VCALENDAR
BEGIN:VTIMEZONE
TZID:Europe/Vienna
X-LIC-LOCATION:Europe/Vienna
BEGIN:STANDARD
TZNAME:CET
DTSTART:19901027T030000
END:STANDARD
BEGIN:DAYLIGHT
TZNAME:CEST
DTSTART:19800329T020000
END:DAYLIGHT
END:VTIMEZONE
BEGIN:VTIMEZONE
TZID:Blablubb
X-LIC-LOCATION:SomewhereElse
BEGIN:STANDARD
TZNAME:CET
DTSTART:19601027T030000
END:STANDARD
BEGIN:DAYLIGHT
TZNAME:CEST
DTSTART:19500329T020000
END:DAYLIGHT
END:VTIMEZONE
BEGIN:VEVENT
SUMMARY:Termin
END:VEVENT
END:VCALENDAR
";

      string expected = @"BEGIN:VCALENDAR
BEGIN:VTIMEZONE
TZID:Europe/Vienna
X-LIC-LOCATION:Europe/Vienna
BEGIN:DAYLIGHT
TZNAME:CEST
DTSTART:19800329T020000
END:DAYLIGHT
BEGIN:STANDARD
TZNAME:CET
DTSTART:19901027T030000
END:STANDARD
END:VTIMEZONE
BEGIN:VTIMEZONE
TZID:Blablubb
X-LIC-LOCATION:SomewhereElse
BEGIN:DAYLIGHT
TZNAME:CEST
DTSTART:19500329T020000
END:DAYLIGHT
BEGIN:STANDARD
TZNAME:CET
DTSTART:19601027T030000
END:STANDARD
END:VTIMEZONE
BEGIN:VEVENT
SUMMARY:Termin
END:VEVENT
END:VCALENDAR
";

      var processed = CalendarDataPreprocessor.FixTimeZoneComponentOrderNoThrow (input);

      Assert.That (processed, Is.EqualTo (expected));
    }

    [Test]
    public void FixTimeZoneComponentOrder_CalenderDataIsNull_ReturnsNull ()
    {
      Assert.That (CalendarDataPreprocessor.FixTimeZoneComponentOrderNoThrow (null), Is.Null);
    }


    private static void AssertCanDeserialize (string iCalData)
    {
      Assert.That (
          () => DeserializeICalendar (iCalData),
          Throws.Nothing);
    }


    private static IICalendar DeserializeICalendar (string iCalData)
    {
      using (var reader = new StringReader (iCalData))
      {
        var calendarCollection = (iCalendarCollection) new iCalendarSerializer().Deserialize (reader);
        return calendarCollection[0];
      }
    }
  }
}