
Feature: The Berlin Clock
	As a clock enthusiast
    I want to tell the time using the Berlin Clock
    So that I can increase the number of ways that I can read the time


Scenario: Midnight 00:00
When the time is "00:00:00"
Then the clock should look like
"""
Y
OOOO
OOOO
OOOOOOOOOOO
OOOO
"""


Scenario: Middle of the afternoon
When the time is "13:17:01"
Then the clock should look like
"""
O
RROO
RRRO
YYROOOOOOOO
YYOO
"""

Scenario: Just before midnight
When the time is "23:59:59"
Then the clock should look like
"""
O
RRRR
RRRO
YYRYYRYYRYY
YYYY
"""

Scenario: Midnight 24:00
When the time is "24:00:00"
Then the clock should look like
"""
Y
RRRR
RRRR
OOOOOOOOOOO
OOOO
"""

Scenario: first quarter 20:15
When the time is "20:15:00"
Then the clock should look like
"""
Y
RRRR
OOOO
YYROOOOOOOO
OOOO
"""

Scenario: thired quarter 19:39
When the time is "19:39:00"
Then the clock should look like
         """
         Y
		 RRRO
		 RRRR
		 YYRYYRYOOOO
		 YYYY
         """
Scenario: morning 10:52
When the time is "10:52:00"
Then the clock should look like
         """
         Y
		 RROO
		 OOOO
		 YYRYYRYYRYO
		 YYOO
         """