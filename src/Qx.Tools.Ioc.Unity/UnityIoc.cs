using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Qx.Report.Interfaces;
using Qx.Report.Services;
using Qx.Contents.Interfaces;
using Qx.Contents.Services;
using Qx.Wechat.Entity;
using Qx.Wechat.Repository;
using Qx.Wechat.Interfaces;
using Qx.Wechat.Services;
using Qx.Account.Interfaces;
using Qx.Account.Services;
using Qx.Order.Entity;
using Qx.Order.Interfaces;
using Qx.Order.Repository;
using Qx.Order.Services;
using Qx.Org.Interfaces;
using Qx.Org.Services;
using Qx.Tools.Interfaces;
using qx.permmision.v2.Interfaces;
using qx.permmision.v2.Services;
//using Qx.Bysj.Jzxt.Interfaces;
//using Qx.Bysj.Jzxt.Repository;
////using Qx.Bysj.Jzxt.Services;
//using Qx.Tools.Ioc.Unity.Provider;
using XiaoTuan.Interfaces;
using XiaoTuan.Service;
using XiaoTuan.Entity;
using XiaoTuan.Repository;

namespace Qx.Tools.Ioc.Unity
{
    public static class UnityIoc
    {
        public static void Register(List<Type> controllers)
        {
            //Container
            IUnityContainer container = new UnityContainer();
            //Register controllers
            controllers.ForEach(c => container.RegisterType(c));
            //Register Services
            RegisterServices(container);
            //Resolver
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        static void RegisterServices(IUnityContainer container)
        {
            #region XiaTuan
            container.RegisterType<IXiaoTuanService, XiaoTuanService>();
            container.RegisterType<IRepository<activity>, activityRepository>();
            container.RegisterType<IRepository<XiaoTuan.Entity.enroll>, XiaoTuan.Repository.enrollRepository>();
            container.RegisterType<IRepository<XiaoTuan.Entity.student>, XiaoTuan.Repository.studentRepository>();
            #endregion
            
            #region Permission Repository
            container.RegisterType<IRepository<qx.permmision.v2.Entity.button>, qx.permmision.v2.Repository.ButtonRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.menu>, qx.permmision.v2.Repository. MenuRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.role_button_forbid>, qx.permmision.v2.Repository. RoleButtonForbidRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.role_menu>, qx.permmision.v2.Repository. RoleMenuRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.role>, qx.permmision.v2.Repository. RoleRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.permission_user>, qx.permmision.v2.Repository.UserRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.user_role>, qx.permmision.v2.Repository. UserRoleRepository>();
            container.RegisterType<IPermissionProvider, PermissionProvider>();
            container.RegisterType<IPermmisionService,PermissionServices>();

            container.RegisterType<IRepository<qx.permmision.v2.Entity.user_group>, qx.permmision.v2.Repository.UserGroupRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.user_group_relation>, qx.permmision.v2.Repository.UserGroupRelationRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.role_group>, qx.permmision.v2.Repository.RoleGroupRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.role_group_relation>, qx.permmision.v2.Repository.RoleGroupRelationRepository>();
           
           
            #endregion

            #region Wechat  Repository
            container.RegisterType<IRepository<ImageMsg>, ImageMsgRepository>();
            container.RegisterType<IRepository<LinkMsg>, LinkMsgRepository>();
            container.RegisterType<IRepository<LocationEvent>, LocationEventRepository>();
            container.RegisterType<IRepository<LocationMsg>, LocationMsgRepository>();
            container.RegisterType<IRepository<Log>, LogRepository>();
            container.RegisterType<IRepository<MenuEvent>, MenuEventRepository>();
            container.RegisterType<IRepository<NewsMsgItem>, NewsMsgItemRepository>();
            container.RegisterType<IRepository<ReplyImageMsg>, ReplyImageMsgRepository>();
            container.RegisterType<IRepository<ReplyMusicMsg>, ReplyMusicMsgRepository>();
            container.RegisterType<IRepository<ReplyNewsMsg>, ReplyNewsMsgRepository>();
            container.RegisterType<IRepository<ReplySetup>, ReplySetupRepository>();
            container.RegisterType<IRepository<ReplyTextMsg>, ReplyTextMsgRepository>();
            container.RegisterType<IRepository<ReplyVideoMsg>, ReplyVideoMsgRepository>();
            container.RegisterType<IRepository<ReplyVoiceMsg>, ReplyVoiceMsgRepository>();
            container.RegisterType<IRepository<ShortVideoMsg>, ShortVideoMsgRepository>();
            container.RegisterType<IRepository<SubscribeEvent>, SubscribeEventRepository>();
            container.RegisterType<IRepository<SystemSetup>, SystemSetupRepository>();
            container.RegisterType<IRepository<TextMsg>, TextMsgRepository>();
            container.RegisterType<IRepository<Token>, TokenRepository>();
            container.RegisterType<IRepository<VideoMsg>, VideoMsgRepository>();
            container.RegisterType<IRepository<VoiceMsg>, VoiceMsgRepository>();
            container.RegisterType<IRepository<ReplyMsg>, ReplyMsgRepository>();
            //失物招领
            //container.RegisterType<ILostAndFoundServices, LostAndFoundServices>();
            // container.RegisterType<IWeChatBll, WeChatBll>();


            #endregion

            #region Provider
            //container.RegisterType<IInvoicingProvider, InvoicingProvider>();
            //container.RegisterType<IEmployeeProvider, EmployeeProvider>();
            container.RegisterType<IPermissionProvider, PermissionProvider>();
            // container.RegisterType<IProductProvider, InvoicingProductProvider>();
            container.RegisterType<IAccountProvider, AccountProvider>();
            container.RegisterType<IOrderProvider, OrderProvider>();
            //container.RegisterType<IMemberProvider, MemberProvider>();
            // container.RegisterType<IFastOrg, Qx.Tools.Ioc.Unity.FastCarProvider>();
            container.RegisterType<IOrgProvider, OrgProvider>();




            #endregion

            #region Service
            container.RegisterType<IContents, ContentService>();
            //container.RegisterType<IMemberServices,MemberServices>();
            //container.RegisterType<IInvoicingServices, InvoicingServices>();
            container.RegisterType<IAccountPayService, AccountPayService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IReportServices, ReportServices>();
            //    container.RegisterType<IStockRightServices, StockRightServices>();
            //container.RegisterType<IPermission, PermissionServices>();
            container.RegisterType<IOrg, OrgServices>();
            //container.RegisterType<IProfitServices, ProfitServices>();
            // container.RegisterType<ITaskServices, TaskServices>();


            #endregion
            
            //#region bysj
            //container.RegisterType<IJzxtService, JzxtService>();
            //container.RegisterType<IRepository<Qx.Bysj.Jzxt.Entity.allocation_for_award>, allocation_for_awardRepository>();
            //container.RegisterType<IRepository<Qx.Bysj.Jzxt.Entity.apply_information_type>, apply_information_typeRepository>();
            //container.RegisterType<IRepository<Qx.Bysj.Jzxt.Entity.audit_by_institute>, audit_by_instituteRepository>();
            //container.RegisterType<IRepository<Qx.Bysj.Jzxt.Entity.audit_object>, audit_objectRepository>();
            //container.RegisterType<IRepository<Qx.Bysj.Jzxt.Entity.audit_object_apply>, audit_object_applyRepository>();
            //container.RegisterType<IRepository<Qx.Bysj.Jzxt.Entity.audit_object_apply_extend>, audit_object_apply_extendRepository>();
            //container.RegisterType<IRepository<Qx.Bysj.Jzxt.Entity.audit_object_award>, audit_object_awardRepository>();

            //container.RegisterType<IRepository<Qx.Bysj.Jzxt.Entity.audit_object_information_for_award>, audit_object_information_for_awardRepository>();
            //container.RegisterType<IRepository<Qx.Bysj.Jzxt.Entity.audit_object_information_type>, audit_object_information_typeRepository>();
            //container.RegisterType<IRepository<Qx.Bysj.Jzxt.Entity.award_list_design>, award_list_designRepository>();
            //container.RegisterType<IRepository<Qx.Bysj.Jzxt.Entity.award_type>, award_typeRepository>();
            //container.RegisterType<IRepository<Qx.Bysj.Jzxt.Entity.data_list_design>, data_list_designRepository>();
            //container.RegisterType<IRepository<Qx.Bysj.Jzxt.Entity.data_list_option>, data_list_optionRepository>();
            //container.RegisterType<IRepository<Qx.Bysj.Jzxt.Entity.data_list_type>, data_list_typeRepository>();
            //container.RegisterType<IRepository<Qx.Bysj.Jzxt.Entity.data_list_Value>, data_list_ValueRepository>();
            //container.RegisterType<IRepository<Qx.Bysj.Jzxt.Entity.data_type>, data_typeRepository>();
            //container.RegisterType<IRepository<Qx.Bysj.Jzxt.Entity.data_use_history>, data_use_historyRepository>();
            //container.RegisterType<IRepository<Qx.Bysj.Jzxt.Entity.Jurisdiction_For_Auditdata>, Jurisdiction_For_AuditdataRepository>();

            //container.RegisterType<IRepository<Qx.Bysj.Jzxt.Entity.Jurisdiction_For_Award>, Jurisdiction_For_AwardRepository>();
            //container.RegisterType<IRepository<Qx.Bysj.Jzxt.Entity.operation>, operationRepository>();
            //container.RegisterType<IRepository<Qx.Bysj.Jzxt.Entity.review_rule>, review_ruleRepository>();
            //container.RegisterType<IRepository<Qx.Bysj.Jzxt.Entity.review_type>, review_typeRepository>();

            //container.RegisterType<IRepository<Qx.Bysj.Jzxt.Entity.reviewer>, reviewerRepository>();
            //container.RegisterType<IRepository<Qx.Bysj.Jzxt.Entity.unit>, unitRepository>();


            //#endregion
            
        }

    }
}
