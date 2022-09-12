Feature: ProgressBar

Test the work of progress bar

@Task
Scenario: Download finished successfully
	Given I am at the Progress bar page 'https://www.globalsqa.com/demo-site/progress-bar/'
	When I click on Start download button 
	Then I should see download finished
