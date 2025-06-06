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
    public class R0553_00_INSERT_PLANO_ETARIA_DB_INSERT_1_Insert1 : QueryBasis<R0553_00_INSERT_PLANO_ETARIA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.PLANOS_FAIXAETA
            VALUES (:PLANOFAI-NUM-APOLICE ,
            :PLANOFAI-COD-SUBGRUPO ,
            :PLANOFAI-COD-PLANO ,
            :PLANOFAI-FAIXA ,
            :PLANOFAI-IDADE-INICIAL ,
            :PLANOFAI-IDADE-FINAL ,
            :PLANOFAI-PRM-VG ,
            :PLANOFAI-PRM-AP ,
            NULL ,
            :PLANOFAI-DATA-INIVIGENCIA,
            :PLANOFAI-DATA-TERVIGENCIA)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PLANOS_FAIXAETA VALUES ({FieldThreatment(this.PLANOFAI_NUM_APOLICE)} , {FieldThreatment(this.PLANOFAI_COD_SUBGRUPO)} , {FieldThreatment(this.PLANOFAI_COD_PLANO)} , {FieldThreatment(this.PLANOFAI_FAIXA)} , {FieldThreatment(this.PLANOFAI_IDADE_INICIAL)} , {FieldThreatment(this.PLANOFAI_IDADE_FINAL)} , {FieldThreatment(this.PLANOFAI_PRM_VG)} , {FieldThreatment(this.PLANOFAI_PRM_AP)} , NULL , {FieldThreatment(this.PLANOFAI_DATA_INIVIGENCIA)}, {FieldThreatment(this.PLANOFAI_DATA_TERVIGENCIA)})";

            return query;
        }
        public string PLANOFAI_NUM_APOLICE { get; set; }
        public string PLANOFAI_COD_SUBGRUPO { get; set; }
        public string PLANOFAI_COD_PLANO { get; set; }
        public string PLANOFAI_FAIXA { get; set; }
        public string PLANOFAI_IDADE_INICIAL { get; set; }
        public string PLANOFAI_IDADE_FINAL { get; set; }
        public string PLANOFAI_PRM_VG { get; set; }
        public string PLANOFAI_PRM_AP { get; set; }
        public string PLANOFAI_DATA_INIVIGENCIA { get; set; }
        public string PLANOFAI_DATA_TERVIGENCIA { get; set; }

        public static void Execute(R0553_00_INSERT_PLANO_ETARIA_DB_INSERT_1_Insert1 r0553_00_INSERT_PLANO_ETARIA_DB_INSERT_1_Insert1)
        {
            var ths = r0553_00_INSERT_PLANO_ETARIA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0553_00_INSERT_PLANO_ETARIA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}