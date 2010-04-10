AutoMapperAssist is a small library that I use to assist my use of AutoMapper.  

I love AutoMapper and use it a lot, but I don't like to see it in my projects and I don't like to mock it in my tests.  Since I use AutoMapper specifically to map data from like objects, AutoMapperAssist includes a simple Mapper<TFrom, TDestination> class that has methods for doing the types of mapping I need.  Like so:

	var mapper = new Mapper<Person, PersonView>();

	var view = mapper.CreateInstance(new Person{ Name = "TEST"});
	
	var views = mapper.CreateSet(new []{ new Person(), new Person()});
	
	var viewToTest = new PersonView();
	mapper.LoadIntoInstance(new Person{ Name = "TEST"}, viewToTest);

Internally, it uses its own instance of AutoMapper, so I can use it for most functionality without even directly referencing AutoMapper.  It also has constructor overloads to pass in AutoMapper's Configuration or IMappingEngine, if desired.  

It also contains a helper method to expose the AssertConfigurationIsValid method, like so:
	
	mapper.AssertConfigurationIsValid();