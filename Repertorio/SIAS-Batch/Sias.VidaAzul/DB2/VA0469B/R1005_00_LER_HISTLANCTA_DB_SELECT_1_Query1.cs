using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0469B
{
    public class R1005_00_LER_HISTLANCTA_DB_SELECT_1_Query1 : QueryBasis<R1005_00_LER_HISTLANCTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CERTIFICADO
            INTO :HISLANCT-NUM-CERTIFICADO
            FROM SEGUROS.HIST_LANC_CTA
            WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO
            AND NUM_PARCELA = :RELATORI-NUM-PARCELA
            AND CODCONV = 6090
            AND SIT_REGISTRO NOT IN ( ' ' , '1' , '2' , '8' )
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_CERTIFICADO
											FROM SEGUROS.HIST_LANC_CTA
											WHERE NUM_CERTIFICADO = '{this.RELATORI_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.RELATORI_NUM_PARCELA}'
											AND CODCONV = 6090
											AND SIT_REGISTRO NOT IN ( ' ' 
							, '1' 
							, '2' 
							, '8' )
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string HISLANCT_NUM_CERTIFICADO { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }

        public static R1005_00_LER_HISTLANCTA_DB_SELECT_1_Query1 Execute(R1005_00_LER_HISTLANCTA_DB_SELECT_1_Query1 r1005_00_LER_HISTLANCTA_DB_SELECT_1_Query1)
        {
            var ths = r1005_00_LER_HISTLANCTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1005_00_LER_HISTLANCTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1005_00_LER_HISTLANCTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISLANCT_NUM_CERTIFICADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}