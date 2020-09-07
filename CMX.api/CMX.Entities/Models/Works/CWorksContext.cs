using CMX.Entities.Models.UIModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMX.Entities.Models.Works
{
    public class CWorksContext : DbContext
    {
        // Methods
        public CWorksContext(DbContextOptions<CWorksContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable<Account>("Account");
            modelBuilder.Entity<DebtorInformation>().ToTable<DebtorInformation>("DebtorInformation");
            modelBuilder.Entity<PersonAddress>().ToTable<PersonAddress>("PersonAddress");
            modelBuilder.Entity<ClientInformation>().ToTable<ClientInformation>("ClientInformation");
            modelBuilder.Entity<AccountStatus>().ToTable<AccountStatus>("AccountStatus");
            modelBuilder.Entity<CWX_AccountTicket>().ToTable<CWX_AccountTicket>("CWX_AccountTicket");
            modelBuilder.Entity<CWX_AccountTicketActivity>().ToTable<CWX_AccountTicketActivity>("CWX_AccountTicketActivity");
            modelBuilder.Entity<Employee>().ToTable<Employee>("Employee");
            modelBuilder.Entity<AvailableActions>().ToTable<AvailableActions>("AvailableActions");
            modelBuilder.Entity<AccountCodeMaster>().ToTable<AccountCodeMaster>("AccountCodeMaster");
            modelBuilder.Entity<RuleOthers>().ToTable<RuleOthers>("RuleOthers");
            modelBuilder.Entity<RuleCriteria>().ToTable<RuleCriteria>("RuleCriteria");
            modelBuilder.Entity<CWX_AccountTicketActivityAction>().ToTable<CWX_AccountTicketActivityAction>("CWX_AccountTicketActivityAction");
            modelBuilder.Entity<NotesCurrent>().ToTable<NotesCurrent>("NotesCurrent");
            modelBuilder.Entity<CWX_TicketApproval>().ToTable<CWX_TicketApproval>("CWX_TicketApproval");
            modelBuilder.Entity<AccountPromise>().ToTable<AccountPromise>("AccountPromise");
            modelBuilder.Entity<AccountActionsOther>().ToTable<AccountActionsOther>("AccountActionsOther");
            modelBuilder.Entity<AccountActions>().ToTable<AccountActions>("AccountActions");
            modelBuilder.Entity<PersonPhone>().ToTable<PersonPhone>("PersonPhone");
            modelBuilder.Entity<InformationTable>().ToTable<InformationTable>("InformationTable");
            modelBuilder.Entity<PersonInformation>().ToTable<PersonInformation>("PersonInformation");
            modelBuilder.Entity<Messages>().ToTable<Messages>("Messages");
        }

        // Properties
        public DbSet<Account> Account { get; set; }

        public DbSet<DebtorInformation> DebtorInformation { get; set; }

        public DbSet<PersonAddress> PersonAddress { get; set; }

        public DbSet<ClientInformation> ClientInformation { get; set; }

        public DbSet<AccountStatus> AccountStatus { get; set; }

        public DbSet<CWX_AccountTicket> CWX_AccountTicket { get; set; }

        public DbSet<CWX_AccountTicketActivity> CWX_AccountTicketActivity { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<AvailableActions> AvailableActions { get; set; }

        public DbSet<AccountCodeMaster> AccountCodeMaster { get; set; }

        public DbSet<RuleTable> RuleTable { get; set; }

        public DbSet<RuleOthers> RuleOthers { get; set; }

        public DbSet<RuleCriteria> RuleCriteria { get; set; }

        public DbSet<CWX_AccountTicketActivityAction> CWX_AccountTicketActivityAction { get; set; }

        public DbSet<NotesCurrent> NotesCurrent { get; set; }

        public DbSet<CWX_TicketApproval> CWX_TicketApproval { get; set; }

        public DbSet<AccountPromise> AccountPromise { get; set; }

        public DbSet<AccountActionsOther> AccountActionsOther { get; set; }

        public DbSet<AccountActions> AccountActions { get; set; }

        public DbSet<PersonPhone> PersonPhone { get; set; }

        public DbSet<InformationTable> InformationTable { get; set; }

        public DbSet<PersonInformation> PersonInformation { get; set; }

        public DbSet<Messages> Messages { get; set; }

        public DbSet<AccountPromiseCriteriaView> AccountPromiseCriteriaView { get; set; }

        public DbSet<AccountPromiseMaxIdView> AccountPromiseMaxIdView { get; set; }

        public DbSet<CMX_AccountPromise_GetPromiseListView> CMX_AccountPromise_GetPromiseListView { get; set; }

        public DbSet<CMX_AccountWorkplanView> CMX_AccountWorkplanView { get; set; }

        public DbSet<CMX_AccountTodoListView> CMX_AccountTodoListView { get; set; }

        public DbSet<CMX_GetMessagingView> CMX_GetMessagingView { get; set; }

        public DbSet<CMX_AccountListView> CMX_AccountListView { get; set; }

        public DbSet<CMX_NotesSearchView> CMX_NotesSearchView { get; set; }

        public DbSet<CMX_LoginView> CMX_LoginView { get; set; }

        public DbSet<CMX_AccountCollateral_GetListView> CMX_AccountCollateral_GetListView { get; set; }

        public DbSet<CMX_AccountCollateral_GetView> CMX_AccountCollateral_GetView { get; set; }

        public DbSet<CMX_ActionListView> CMX_ActionListView { get; set; }

        public DbSet<CMX_GetSWDView> CMX_GetSWDView { get; set; }

        public DbSet<CMX_AccountForReviewView> CMX_AccountForReviewView { get; set; }
    }
}
