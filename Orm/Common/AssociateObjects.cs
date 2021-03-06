using System.Collections.Generic;
using Leafing.Data.Definition;

namespace OrmCommon
{
    [DbTable("People")]
    public class Person : DbObjectModel<Person>
    {
        [Length(50)]
        public string Name { get; set; }

        [OrderBy("Id DESC")]
        public HasOne<PersonalComputer> mPC { get; private set; }

        [Exclude]
        public PersonalComputer PC
        {
            get { return mPC.Value; }
            set { mPC.Value = value; }
        }
    }

    [DbTable("PCs")]
    public class PersonalComputer : DbObjectModel<PersonalComputer>
    {
        [Length(50)]
        public string Name { get; set; }

        [DbColumn("Person_Id")]
        public BelongsTo<Person, long> mOwner { get; private set; }

        [Exclude]
        public Person Owner
        {
            get { return mOwner.Value; }
            set { mOwner.Value = value; }
        }
    }

    [DbTable("Books")]
    public class Book : DbObjectModel<Book>
    {
        [Length(50)]
        public string Name { get; set; }

        [DbColumn("Category_Id")]
        public BelongsTo<Category, long> mCategory { get; private set; }

        [Exclude]
        public Category Category
        {
            get { return mCategory.Value; }
            set { mCategory.Value = value; }
        }
    }

    [DbTable("Categories")]
    public class Category : DbObjectModel<Category>
    {
        [Length(50)]
        public string Name { get; set; }

        [OrderBy("Id")]
        public HasMany<Book> Books { get; private set; }
    }

    public class Article : DbObjectModel<Article>
    {
        public string Name { get; set; }

        [OrderBy("Id")]
        public HasAndBelongsToMany<Reader> Readers { get; private set; }
    }

    public class Reader : DbObjectModel<Reader>
    {
        public string Name { get; set; }

        [OrderBy("Id")]
        public HasAndBelongsToMany<Article> Articles { get; private set; }
    }
}
