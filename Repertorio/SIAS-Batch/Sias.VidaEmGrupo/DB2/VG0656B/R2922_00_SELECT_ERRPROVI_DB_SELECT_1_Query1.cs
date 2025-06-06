using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0656B
{
    public class R2922_00_SELECT_ERRPROVI_DB_SELECT_1_Query1 : QueryBasis<R2922_00_SELECT_ERRPROVI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MIN(T1.COD_MSG_CRITICA),0)
            INTO :ERRPROVI-COD-ERRO
            FROM SEGUROS.VG_CRITICA_PROPOSTA T1,
            SEGUROS.VG_DM_MSG_CRITICA T2
            WHERE T1.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND T1.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' )
            AND T1.COD_MSG_CRITICA = T2.COD_MSG_CRITICA
            AND T2.COD_TP_MSG_CRITICA <> '3'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MIN(T1.COD_MSG_CRITICA)
							,0)
											FROM SEGUROS.VG_CRITICA_PROPOSTA T1
							,
											SEGUROS.VG_DM_MSG_CRITICA T2
											WHERE T1.NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND T1.STA_CRITICA IN ( '0' 
							, '1' 
							, '2' 
							, '4' 
							, '5' 
							, '8' )
											AND T1.COD_MSG_CRITICA = T2.COD_MSG_CRITICA
											AND T2.COD_TP_MSG_CRITICA <> '3'";

            return query;
        }
        public string ERRPROVI_COD_ERRO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R2922_00_SELECT_ERRPROVI_DB_SELECT_1_Query1 Execute(R2922_00_SELECT_ERRPROVI_DB_SELECT_1_Query1 r2922_00_SELECT_ERRPROVI_DB_SELECT_1_Query1)
        {
            var ths = r2922_00_SELECT_ERRPROVI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2922_00_SELECT_ERRPROVI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2922_00_SELECT_ERRPROVI_DB_SELECT_1_Query1();
            var i = 0;
            dta.ERRPROVI_COD_ERRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}