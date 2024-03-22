using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp3.Pages
{
    public class IndexBase : ComponentBase
    {
        [ValidateComplexType] public User User { get; set; } = null!;
        public EditContext Context { get; private set; } = null!;

        public bool? IsFormValid { get; set; }

        protected override void OnInitialized()
        {
            User = new()
            {
                Id = 1,
                Name = "John",
                Addresses =
                [
                    new()
                    {
                        Street = "Name 1",
                        Number = 10
                    },
                    new Address
                    {
                        Street = "Name 2",
                        Number = 3
                    }
                ]
            };

            base.OnInitialized();
            Context = new EditContext(User);
        }

        public void Validate()        
            => IsFormValid = Context.Validate();
    }
    public class Address
    {
        [Required, MinLength(3)]
        public string Street { get; set; } = string.Empty;

        [Required, Range(1, 4)]
        public int Number { get; set; }
    }

    public class User
    {
        [Required, Range(0, int.MaxValue)]
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; } = string.Empty;

        public List<Address> Addresses { get; set; } = [];
    }

}
