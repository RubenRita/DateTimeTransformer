#.NET CORE -> Job Interview 

Each traveler has a personalized overview of their upcoming trips. These trip items are supported with a notification to provide more relative content to the traveler.
The responsibility of DateTimeTransformer is to determine the send date and time when a push notification should be sent.

#.GIVEN
  - PointDate – contains the given start and end date and time of a trip item
  - TemplateValue – contains the indicator like 'first' and added minutes or 'end' and added minutes.
  
#.GOAL
  - Implement business logic in the most efficient way and make all tests pass.
  - Unit tests are written and should not be changed.
  
#.EXAMPLES
  - When a trip item starts at 2019-04-01 12:00 and ends at 2019-04-01 18:00 and the given template value is ‘last’, a push notification should be sent on the last date and time of the trip item and thus 2019-04-01 18:00.
  - When a trip item starts at 2019-04-01 12:00 and ends at 2019-04-01 18:00 and the given template value is ‘first+2880’, a push notification should be sent on the first date and time of the trip item plus 2880 minutes and thus 2019-04-03 12:00.

The dotnet/core 2.2 repository is a good starting point for .NET Core.


