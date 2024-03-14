using System.ComponentModel;

namespace APIs.Permissions
{
    public enum Permission
    {
        [Description("إنشاء موضوع")]
        ThreadCreate,

        [Description("قراءة موضوع")]
        ThreadView,

        [Description("المشاركة في موضوع")]
        ThreadAddPost,

        [Description("تغيير حالة موضوع")]
        ThreadChangeState,

        [Description("حذف موضوع")]
        ThreadDelete,

        [Description("تثبيت موضوع")]
        ThreadPin,

        [Description("تثبيت مشاركة")]
        ThreadPostPin,





        [Description("إنشاء دعوة")]
        InvitationCreate,

        [Description("إنشاء دعوة بدون اسم")]
        InvitationAnonymous,




        [Description("إنشاء موضوع إداري")]
        AdminThreadCreate,

        [Description("مشاركة في موضوع إداري")]
        AdminThreadPost,

        [Description("قراءة موضوع إداري")]
        AdminThreadView,

        [Description("حذف موضوع إداري")]
        AdminThreadDelete,





        [Description("إنشاء قرار")]
        DecisionCreate,

        [Description("حذف قرار")]
        DecisionDelete,

        [Description("نشر قرار")]
        DecisionPublish,





        [Description("إنشاء خدمة")]
        ServiceCreate,

        [Description("تعديل خدمة")]
        ServiceChange,

        [Description("حذف خدمة")]
        ServiceDelete,

        [Description("إنشاء دورة خدمة")]
        ServiceCreateCycle,

        [Description("ضم للخدمة")]
        ServiceSubscription,





        [Description("إنشاء شكوى")]
        CompliantCreate,

        [Description("رد وتعديل حالة شكوى")]
        CompliantChange,

        [Description("استعراض الشكاوى")]
        CompliantView,





        [Description("استعراض التقارير")]
        ReportView,





        [Description("إنشاء العمليات المالية")]
        TransactionCreate,

        [Description("تعديل بيانات مالية")]
        TransactionEdit,

        [Description("حذف عمليات مالية")]
        TransactionDelete,

        [Description("عرض العمليات المالية على الصندوق")]
        TransactionView,





        [Description("إنشاء تقييم للمجتمع")]
        EvaluationCreate,

        [Description("المشاركة في تقييم المجتمع")]
        EvaluationVote,





        [Description("تعديل بيانات اللجنة/المجتمع")]
        CommunityChangeInfo,

        [Description("قبول طلبات الانضمام")]
        CommunityJoinAccept,

        [Description("توليد كود الانضمام")]
        CommunityCreateJoinQR,





        [Description("إدارة صلاحيات المستخدمين")]
        UserPermissionChange
    }
}