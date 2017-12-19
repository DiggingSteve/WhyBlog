This is a .NetCore project. Please use dependency injection.

1.WhyBlog ->Web layout 

2.WhyBlog.EF -> Service=> Persistent layer to database (DAO)

3.WhyBlog.Infrastructure ->Including some public class implement

4.WhyBlog.Models->  Do=>Data object mapping to database,
					Dto=>Data transform to DominService,
					Vo=>View Data

5.WhyBlog.DominService-> Receive dto from view layer, define the domin event flow ,then call the Bussiness to process by the flow.

6.WhyBlog.Bussiness-> SubDivde the bussiness flow

7.WhyBlog.WebApi-> MVC webapi that  hosting in WhyBlog
						
