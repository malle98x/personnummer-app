# Personnummer-applikation

Grupp 4: Sebri, Malek, Sanjar och Helen

Detta projekt är en .NET Console App som vi har skapat för gruppuppgiften. Applikationen har grundläggande funktioner och varje funktion har motsvarande xUnit-test, enhetstest. Applikationen används för kontroll av svenskt personnummer.

Svenskt personnummer är centralt för många administrativa och identifikationsändamål. Skatteverket tilldelar alla personer som är folkbokföra i Sverige ett identifieringsnummer. Utöver dess funktion för identifiering används personnumret också för att beräkna ålder och kontrollera giltighet i olika sammanhang, som myndighetskontakter, hälso- och sjukvård samt bankärenden. Det är viktigt att notera att personnummer i Sverige utgår från noggranna regler och skyddsåtgärder för att säkerställa personlig integritet och säkerhet som regleras i folkbokföringslagen.

# Validering av personnummer 

Ett svenskt personnummer består av 10 eller 12 sifffror beroende på om man vill ha med århundradet eller inte.
Formatet är:
ÅÅÅÅMMDD-XXXX (Vid 12 siffror)
ÅÅMMDD-XXXX (Vid 10 siffror)

Ett giltigt personnummer måste bestå av 10 eller 12 siffror. Om fel antal siffror matas in får användaren försöka igen. Personnumret måste också innehålla ett giltigt datum i formaten ÅÅMMDD (10 siffror) eller ÅÅÅÅMMDD (12 siffror), vilket kontrolleras med DateTime.TryParseExact. Om datumet inte är giltigt visas ett felmeddelande.

Kontrollsiffran (den sista siffran) valideras med Luhn-algoritmen. Den beräknar de första 9 siffrorna (för 10-siffriga personnummer) eller de första 11 siffrorna (för 12-siffriga personnummer) och jämför resultatet med kontrollsiffran.

Den näst sista siffran visar kön: udda för man och jämn för kvinna. Detta kontrolleras med modulusoperatorn (%).

# Docker-container

Vi har genom att bygga en Docker laddadat upp vår Docker-container till Docker Hub. Applikationen kan köras i containern med kommando lokalt från källkod eller i webbläsaren. Vi skapade en lösning som är både skalbar och användarvänlig.  

Användaren kan köra vår applikation med följande kommando:
docker run -it malle98x/personnummer-app:latest

Detta möjliggör interaktiv input av personnummer direkt i terminalen.

Felhantering
Vi säkerställde att applikationen ger tydliga felmeddelanden om något går fel, som ogiltiga personnummer eller saknad -it-flagga.

För att köra den lokalt kan användaren klona repot https://github.com/malle98x/personnummer-app.git .Navigera till projektmappen. Köra kommando för att starta applikationen:
dotnet run --project personnummer-applikation-test.csproj


# Köra applikationen lokalt

Förutsättningar
NET SDK måste vara installerat (version 9.0 eller senare). Ladda ner och installera .NET SDK här: https://dotnet.microsoft.com/download

Git måste vara installerat.

Steg för steg för att köra applikationen lokalt från källkoden:

Klona GitHub-repot:
Öppna terminalen och kör,
git clone https://github.com/malle98x/personnummer-app.git

Navigera till projektmappen på din dator:

Kör applikationen:
Kör följande kommando för att starta applikationen,
dotnet run --project personnummer-applikation-test.csproj


