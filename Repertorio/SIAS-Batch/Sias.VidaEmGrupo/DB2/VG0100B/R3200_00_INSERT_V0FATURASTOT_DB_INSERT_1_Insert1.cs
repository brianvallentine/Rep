using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0100B
{
    public class R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1_Insert1 : QueryBasis<R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0FATURASTOT
            VALUES (:V0FATT-NUM-APOL ,
            :V0FATT-COD-SUBG ,
            :V0FATT-NUM-FATUR ,
            :V0FATT-COD-OPER ,
            :V0FATT-QT-VIDA-VG ,
            :V0FATT-QT-VIDA-AP ,
            :V0FATT-IMP-MORNAT ,
            :V0FATT-IMP-MORACI ,
            :V0FATT-IMP-INVPER ,
            :V0FATT-IMP-AMDS ,
            :V0FATT-IMP-DH ,
            :V0FATT-IMP-DIT ,
            :V0FATT-PRM-VG ,
            :V0FATT-PRM-AP ,
            :V0FATT-SIT-REG ,
            :V0FATT-COD-EMPRESA:VIND-COD-EMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0FATURASTOT VALUES ({FieldThreatment(this.V0FATT_NUM_APOL)} , {FieldThreatment(this.V0FATT_COD_SUBG)} , {FieldThreatment(this.V0FATT_NUM_FATUR)} , {FieldThreatment(this.V0FATT_COD_OPER)} , {FieldThreatment(this.V0FATT_QT_VIDA_VG)} , {FieldThreatment(this.V0FATT_QT_VIDA_AP)} , {FieldThreatment(this.V0FATT_IMP_MORNAT)} , {FieldThreatment(this.V0FATT_IMP_MORACI)} , {FieldThreatment(this.V0FATT_IMP_INVPER)} , {FieldThreatment(this.V0FATT_IMP_AMDS)} , {FieldThreatment(this.V0FATT_IMP_DH)} , {FieldThreatment(this.V0FATT_IMP_DIT)} , {FieldThreatment(this.V0FATT_PRM_VG)} , {FieldThreatment(this.V0FATT_PRM_AP)} , {FieldThreatment(this.V0FATT_SIT_REG)} ,  {FieldThreatment((this.VIND_COD_EMP?.ToInt() == -1 ? null : this.V0FATT_COD_EMPRESA))})";

            return query;
        }
        public string V0FATT_NUM_APOL { get; set; }
        public string V0FATT_COD_SUBG { get; set; }
        public string V0FATT_NUM_FATUR { get; set; }
        public string V0FATT_COD_OPER { get; set; }
        public string V0FATT_QT_VIDA_VG { get; set; }
        public string V0FATT_QT_VIDA_AP { get; set; }
        public string V0FATT_IMP_MORNAT { get; set; }
        public string V0FATT_IMP_MORACI { get; set; }
        public string V0FATT_IMP_INVPER { get; set; }
        public string V0FATT_IMP_AMDS { get; set; }
        public string V0FATT_IMP_DH { get; set; }
        public string V0FATT_IMP_DIT { get; set; }
        public string V0FATT_PRM_VG { get; set; }
        public string V0FATT_PRM_AP { get; set; }
        public string V0FATT_SIT_REG { get; set; }
        public string V0FATT_COD_EMPRESA { get; set; }
        public string VIND_COD_EMP { get; set; }

        public static void Execute(R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1_Insert1 r3200_00_INSERT_V0FATURASTOT_DB_INSERT_1_Insert1)
        {
            var ths = r3200_00_INSERT_V0FATURASTOT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}