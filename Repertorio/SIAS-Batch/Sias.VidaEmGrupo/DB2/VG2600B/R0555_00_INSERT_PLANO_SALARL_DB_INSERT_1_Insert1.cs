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
    public class R0555_00_INSERT_PLANO_SALARL_DB_INSERT_1_Insert1 : QueryBasis<R0555_00_INSERT_PLANO_SALARL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.PLANOS_FAIXASAL
            VALUES (:PLANFSAL-NUM-APOLICE ,
            :PLANFSAL-COD-SUBGRUPO ,
            :PLANFSAL-COD-PLANO ,
            :PLANFSAL-FAIXA ,
            :PLANFSAL-SALARIO-INICIAL ,
            :PLANFSAL-SALARIO-FINAL ,
            :PLANFSAL-PRM-VG ,
            :PLANFSAL-PRM-AP ,
            NULL )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PLANOS_FAIXASAL VALUES ({FieldThreatment(this.PLANFSAL_NUM_APOLICE)} , {FieldThreatment(this.PLANFSAL_COD_SUBGRUPO)} , {FieldThreatment(this.PLANFSAL_COD_PLANO)} , {FieldThreatment(this.PLANFSAL_FAIXA)} , {FieldThreatment(this.PLANFSAL_SALARIO_INICIAL)} , {FieldThreatment(this.PLANFSAL_SALARIO_FINAL)} , {FieldThreatment(this.PLANFSAL_PRM_VG)} , {FieldThreatment(this.PLANFSAL_PRM_AP)} , NULL )";

            return query;
        }
        public string PLANFSAL_NUM_APOLICE { get; set; }
        public string PLANFSAL_COD_SUBGRUPO { get; set; }
        public string PLANFSAL_COD_PLANO { get; set; }
        public string PLANFSAL_FAIXA { get; set; }
        public string PLANFSAL_SALARIO_INICIAL { get; set; }
        public string PLANFSAL_SALARIO_FINAL { get; set; }
        public string PLANFSAL_PRM_VG { get; set; }
        public string PLANFSAL_PRM_AP { get; set; }

        public static void Execute(R0555_00_INSERT_PLANO_SALARL_DB_INSERT_1_Insert1 r0555_00_INSERT_PLANO_SALARL_DB_INSERT_1_Insert1)
        {
            var ths = r0555_00_INSERT_PLANO_SALARL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0555_00_INSERT_PLANO_SALARL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}