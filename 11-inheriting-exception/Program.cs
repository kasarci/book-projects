Person person = new Person() {ID = 1, Name = "Test"};
if ( person.ID < 1000 )
{
  throw new PersonException("Person IDs should start from 1000");
}