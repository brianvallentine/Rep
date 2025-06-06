using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R0551_00_INSERT_PLAN_MULTISAL_DB_INSERT_1_Insert1 : QueryBasis<R0551_00_INSERT_PLAN_MULTISAL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.PLANOS_MULTISAL
            VALUES (:PLANOMUL-NUM-APOLICE ,
            :PLANOMUL-COD-SUBGRUPO ,
            :PLANOMUL-COD-PLANO ,
            :PLANOMUL-QTD-SAL-MORNATU ,
            :PLANOMUL-QTD-SAL-MORACID ,
            :PLANOMUL-QTD-SAL-INVPERM ,
            :PLANOMUL-LIM-CAP-MORNATU ,
            :PLANOMUL-LIM-CAP-MORACID ,
            :PLANOMUL-LIM-CAP-INVAPER ,
            NULL )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PLANOS_MULTISAL VALUES ({FieldThreatment(this.PLANOMUL_NUM_APOLICE)} , {FieldThreatment(this.PLANOMUL_COD_SUBGRUPO)} , {FieldThreatment(this.PLANOMUL_COD_PLANO)} , {FieldThreatment(this.PLANOMUL_QTD_SAL_MORNATU)} , {FieldThreatment(this.PLANOMUL_QTD_SAL_MORACID)} , {FieldThreatment(this.PLANOMUL_QTD_SAL_INVPERM)} , {FieldThreatment(this.PLANOMUL_LIM_CAP_MORNATU)} , {FieldThreatment(this.PLANOMUL_LIM_CAP_MORACID)} , {FieldThreatment(this.PLANOMUL_LIM_CAP_INVAPER)} , NULL )";

            return query;
        }
        public string PLANOMUL_NUM_APOLICE { get; set; }
        public string PLANOMUL_COD_SUBGRUPO { get; set; }
        public string PLANOMUL_COD_PLANO { get; set; }
        public string PLANOMUL_QTD_SAL_MORNATU { get; set; }
        public string PLANOMUL_QTD_SAL_MORACID { get; set; }
        public string PLANOMUL_QTD_SAL_INVPERM { get; set; }
        public string PLANOMUL_LIM_CAP_MORNATU { get; set; }
        public string PLANOMUL_LIM_CAP_MORACID { get; set; }
        public string PLANOMUL_LIM_CAP_INVAPER { get; set; }

        public static void Execute(R0551_00_INSERT_PLAN_MULTISAL_DB_INSERT_1_Insert1 r0551_00_INSERT_PLAN_MULTISAL_DB_INSERT_1_Insert1)
        {
            var ths = r0551_00_INSERT_PLAN_MULTISAL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0551_00_INSERT_PLAN_MULTISAL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}