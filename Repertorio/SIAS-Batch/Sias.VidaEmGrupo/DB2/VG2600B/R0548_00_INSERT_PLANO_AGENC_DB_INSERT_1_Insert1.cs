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
    public class R0548_00_INSERT_PLANO_AGENC_DB_INSERT_1_Insert1 : QueryBasis<R0548_00_INSERT_PLANO_AGENC_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.PLANO_AGENCIAMENTO
            VALUES (:PLANOAGE-NUM-APOLICE ,
            :PLANOAGE-COD-SUBGRUPO ,
            :PLANOAGE-NUM-PARCELA ,
            :PLANOAGE-PCT-PAGA-PARCELA ,
            NULL ,
            :PLANOAGE-COD-AGENCIADOR ,
            :PLANOAGE-MATRIC-INDICADOR )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PLANO_AGENCIAMENTO VALUES ({FieldThreatment(this.PLANOAGE_NUM_APOLICE)} , {FieldThreatment(this.PLANOAGE_COD_SUBGRUPO)} , {FieldThreatment(this.PLANOAGE_NUM_PARCELA)} , {FieldThreatment(this.PLANOAGE_PCT_PAGA_PARCELA)} , NULL , {FieldThreatment(this.PLANOAGE_COD_AGENCIADOR)} , {FieldThreatment(this.PLANOAGE_MATRIC_INDICADOR)} )";

            return query;
        }
        public string PLANOAGE_NUM_APOLICE { get; set; }
        public string PLANOAGE_COD_SUBGRUPO { get; set; }
        public string PLANOAGE_NUM_PARCELA { get; set; }
        public string PLANOAGE_PCT_PAGA_PARCELA { get; set; }
        public string PLANOAGE_COD_AGENCIADOR { get; set; }
        public string PLANOAGE_MATRIC_INDICADOR { get; set; }

        public static void Execute(R0548_00_INSERT_PLANO_AGENC_DB_INSERT_1_Insert1 r0548_00_INSERT_PLANO_AGENC_DB_INSERT_1_Insert1)
        {
            var ths = r0548_00_INSERT_PLANO_AGENC_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0548_00_INSERT_PLANO_AGENC_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}