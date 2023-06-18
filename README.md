# README #

Основная логика игры разбита на 2 состояния MainMenuState и GameplayState,
при необходимости логику можно расширить добавив новые состояния

Окна реализованы через паттерн MVC, вьюха подписывается на модель, 
контроллер ловит события от вьюхи и выполняет действия с логикой,
контроллеры получились очень маленьке т.к. у окон мало функционала

Сначало сделал иерархию зданий с алгоритмом производства в ресурсном здании, 
и переопределением алгоритма в крафтящем здание. 
Но потом решил что для расширяемости поведения зданий лучше алгоритм производства
вынести в отдельный компонент.
При необходимости расширить поведение зданий можно добавлять им новые компоненты

Все настройки вынесены в файл GameSettings, кроме скорости производства в начале вынес её в настройки, 
затем понял что по тз надо задавать скорость для каждого отдельного здания, поэтому перенёс настройку на префаб здания
