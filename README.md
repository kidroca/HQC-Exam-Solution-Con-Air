# HQC-Exam-Solution-Con-Air
A partial exam solution

## Self Evaluation
### 1. Code Refactoring:
##### Reorganised project structure to follow a common convention
##### Extracted Main Logic 
Into separate controllers conforming a protocol (interface). A CommandDistributor linking the received command to the correct controller (also conforms to a protocol). 
##### Separation of concern: 
Each class/object responsible for more than one items was refactored. 
##### Open/Closed Principle: 
The CommandDistributor can be extended to support aditional commands without modifing it's source code by overriding its virtual Proccess method 
##### Liskov Substitution:  
No examples of this principle. **Not Implemented**.
#####  Interface Segregation: 
Protocols/Interfaces are compact and implementors implement and use all of the interface method and properties. Excep the IAppDataContext which hosts logic for AirConditioners and Reports that can be separated by those criteria.
##### Dependency Inversion: 
Dependency to other object is resolved in the constructors or public properties , no hidden dependencies.
#####  Design Patterns:
* ###### Strategy: 
> By using interfaces and not concrete implementation bussiness logic can be altered by createing a new implementation of the given interface

* ###### Repository: 
> IAppDataContext has methods for adding, removing and listing AirConditioner and Reports

* ###### Bridge: 
> ICommandDistributor is a bridge between the client and the desired functionallity which logic is performed in the controllers

* ###### Template Method: 
> The Air Conditioner's Test() method is left absract so that different implementations can alter this logic. Different air conditioner models override the ToString() method steping on the base.ToString() defined in the abstract implementation
to produce different result but sharing common logic.

#### Score: 22 / 25

### 2.StyleCop - 42 Warnings 
#### Score: 0 / 4

### 3.Bug Fixing
###### There was a bug with the RegisterCarAirConditioner command: model and manufacturer parameters were had switched places.
###### In splitting command parameters -> split should start from the next index.
###### "Passed" or "Failed" was appended to the report word.
#### Score: 3 / 4

### 4.Code Documentation - None of the required documentation added
#### Score: 0 / 7

### 5.Unit Testing - No Unit test created
#### Score: 0 / 30

### 6.Performance Bottlenecks - No Bottlenecks documented
#### Score: 0 / 4

### 7.Correct Results in the Judge System
#### Score: 0 / 16

### 8.Mocking - No Unit Test
#### Score: 0 / 10

### 9*. Dependency Injection -
> Command execution is successfully decoupled by extracting logic into separate controller and injecting them in the constructor body of the CommandDistributor.
Score: 10

### Total: 35 / 110 points.
