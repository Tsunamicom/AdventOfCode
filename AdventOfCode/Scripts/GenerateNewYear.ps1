cls
$Script:Year = 2023
$Script:BasePath = "." # Update BasePath to where this script and template files are dropped


function CreateDirectory()
{
    if(-Not (Test-Path $Script:BasePath\$Script:Year)) {New-Item -Force -Path $Script:BasePath\$Script:Year -ItemType Directory}
}

function CreateResolutionFiles()
{
  $Local:Template = Get-Content -Path "$Script:BasePath\ChallengeTemplate.txt"
  $Local:Template

  $Local:CurrentDayTemplate = $Local:Template
  foreach($Local:Day in 1..25)
  {
    foreach($Local:Part in 1..2)
    {
        
        $Local:CurrentCycleTemplate = $Local:CurrentDayTemplate.
        Replace("@@YEAR@@", $Script:Year).
        Replace("@@DAYSTR@@", $Local:Day.ToString("00")).
        Replace("@@PARTSTR@@", $Local:Part.ToString("00")).
        Replace("@@DAY@@", $Local:Day).
        Replace("@@PART@@", $Local:Part)

        #$Local:CurrentCycleTemplate #| Out-File -FilePath "C:\Users\Tsuna\Desktop\AdventOfCode\Challenge_$Script:Year_$Local:Day_$Local:Part.cs"
        
        $Local:FilePath = "$Script:BasePath\$Script:Year\Challenge`_$Script:Year`_$($Local:Day.ToString("00"))`_0$Local:Part.cs"
        $Local:FilePath

        $Local:CurrentCycleTemplate | Out-File -FilePath $Local:FilePath
    }
    
  }
  
}

function CreateInputFiles()
{
    1..25 | % { Out-File -FilePath "$Script:BasePath\Day$($_.ToString("00"))`.txt" }
}

function CreateTestFile()
{
    $Local:Template = Get-Content -Path "$Script:BasePath\UnitTestTemplate.txt"
    $Local:Template
    
    $Local:FilePath = "$Script:BasePath\$Script:Year\Challenge`_Tests`_$Script:Year.cs"
    $Local:FilePath

    Out-File -FilePath $Local:FilePath -Force

    foreach($Local:Day in 1..25)
    {
        foreach($Local:Part in 1..2)
        {
            
            $Local:CurrentCycleTemplate = $Local:Template.
            Replace("@@YEAR@@", $Script:Year).
            Replace("@@DAYSTR@@", $Local:Day.ToString("00")).
            Replace("@@PARTSTR@@", $Local:Part.ToString("00")).
            Replace("@@DAY@@", $Local:Day).
            Replace("@@PART@@", $Local:Part)
        
            $Local:CurrentCycleTemplate | Out-File -FilePath $Local:FilePath -Append
        }
          
    }
}

function CreateTestFileInputs()
{
    $Local:Template = Get-Content -Path "$Script:BasePath\UnitTestInputTemplate.txt"
    $Local:Template
    
    $Local:FilePath = "$Script:BasePath\$Script:Year\Challenge`_Tests`_TestData`_$Script:Year.cs"
    $Local:FilePath

    Out-File -FilePath $Local:FilePath -Force

    foreach($Local:Day in 1..25)
    {
        $Local:CurrentCycleTemplate = $Local:Template.
        Replace("@@YEAR@@", $Script:Year).
        Replace("@@DAYSTR@@", $Local:Day.ToString("00"))
        
        $Local:CurrentCycleTemplate | Out-File -FilePath $Local:FilePath -Append
    }
}

CreateDirectory
CreateResolutionFiles
CreateInputFiles
CreateTestFile
CreateTestFileInputs