using EfCore.Data;
using EfCore.Pages.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EfCore.Service
{
    public class InterestsService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public static ObservableCollection<InterestGroup> Cources { get; set; } = new();
        public int Commit() => _db.SaveChanges();
        public void Add(InterestGroup cource)
        {
            var _cource = new InterestGroup
            {
                Id = cource.Id,
                Title = cource.Title,
                Description = cource.Description,
            };
            _db.Add<InterestGroup>(_cource);
            Commit();
            Cources.Add(_cource);
        }
        public void GetAll()
        {
            var cources = _db.InterestGroups.ToList();
            Cources.Clear();
            foreach (var cource in cources)
            {
                Cources.Add(cource);
            }
        }
        public InterestsService()
        {
            GetAll();
        }
        public void Remove(InterestGroup cource)
        {
            _db.Remove<InterestGroup>(cource);
            if (Commit() > 0)
                if (Cources.Contains(cource))
                    Cources.Remove(cource);
        }

        public void LoadRelation(InterestGroup group, string relation)
        {
            var entry = _db.Entry(group);
            var navigation = entry.Metadata.FindNavigation(relation)
            ?? throw new InvalidOperationException($"Navigation '{relation}' not found");
if (navigation.IsCollection)
            {
                entry.Collection(relation).Load();
            }
            else
            {
                entry.Reference(relation).Load();
            }
        } } }
