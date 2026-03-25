# APBD Cw2 - Projekt obiektowy w C#

## Krótki opis projektu
Jest to implementacja systemu do zarządzania wypożyczalnią sprzętu zgodnie z wymaganiami.
Daje on możliwość dodawania nowych użytkowników i urządzeń, rejestrację wypożyczeń i zwrotów oraz naliczania kar za opóźnione oddanie.

## Decyzje projektowe
Projekt postanowiłem podzielić na kilka folderów, w których implementuje poszczególne elementy.
- **DomainElements** - klasy, które implementują jednostki domeny - Użytkownicy, Sprzęt, Wypożyczenia
- **Interfaces** - interfejsy dla magazynów danych
- **MyStorages** - implementacja magazynów danych
- **Services** - funkcjonalności i reguły biznesowe
- **Program.cs** - demonstracja działania systemu

## Kohezja
Wszystkie klasy są podzielone zadaniami w taki sposób, żeby jednoznacznie określić w jakich miejsach znajdują się poszczególne elementy projektu, np. RentalStorage odpowiada za przechowywanie i zarządzanie magazynem danych o sprzętach, a Laptop reprezentuje obiekt laptopa

## Coupling
W projekcie występują liczne dziedziczenia zarówno interfejsów jak i klas abstrakcyjnych, dzięki czemu dane zawarte w zwykłych klasach nie zależą wyłącznie od własnych implementacji

## Odpowiedzialność klas
Każda klasa odpowiada za swoją funkcję i ma pojedynczą odpowiedzialność, nie ma bałaganu z tym jaka klasa za co odpowiada. Mamy również przede wszystkim podział na logikę biznesową i model domeny i każdy element systemu, czy to sprzęt czy użytkownik ma własną implementację w logice biznesowej i modelu domeny w oddzielnych klasach.

## Uzasadnienie końcowe
Taki podział klas i plików został użyty, żeby zachowane zostały zasady poprawnej architektury projektu, która pozwala na łatwe odnalezienie się w kodzie, a także łatwy rozwój kodu na nowe funkcjonalności.

## Jak uruchomić?
1. Przejdź do folderu głównego projektu (tego z plikiem APBD-Cw2-s33551.csproj) w konsoli
2. Wpisz "dotnet build", a następnie "dotnet run"