using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0848B
{
    public class Execute_DB_SELECT_2_Query1 : QueryBasis<Execute_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MES_REFERENCIA,
            ANO_REFERENCIA,
            PERI_INICIAL ,
            PERI_FINAL
            INTO :V0RELAT-MES-REFERENCIA,
            :V0RELAT-ANO-REFERENCIA,
            :V0RELAT-PERI-INICIAL ,
            :V0RELAT-PERI-FINAL
            FROM SEGUROS.V0RELATORIOS
            WHERE IDSISTEM = 'SI'
            AND DATA_SOLICITACAO = :V0SIST-DTMOVABE
            AND CODRELAT = 'SI0848B'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MES_REFERENCIA
							,
											ANO_REFERENCIA
							,
											PERI_INICIAL 
							,
											PERI_FINAL
											FROM SEGUROS.V0RELATORIOS
											WHERE IDSISTEM = 'SI'
											AND DATA_SOLICITACAO = '{this.V0SIST_DTMOVABE}'
											AND CODRELAT = 'SI0848B'";

            return query;
        }
        public string V0RELAT_MES_REFERENCIA { get; set; }
        public string V0RELAT_ANO_REFERENCIA { get; set; }
        public string V0RELAT_PERI_INICIAL { get; set; }
        public string V0RELAT_PERI_FINAL { get; set; }
        public string V0SIST_DTMOVABE { get; set; }

        public static Execute_DB_SELECT_2_Query1 Execute(Execute_DB_SELECT_2_Query1 execute_DB_SELECT_2_Query1)
        {
            var ths = execute_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override Execute_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new Execute_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0RELAT_MES_REFERENCIA = result[i++].Value?.ToString();
            dta.V0RELAT_ANO_REFERENCIA = result[i++].Value?.ToString();
            dta.V0RELAT_PERI_INICIAL = result[i++].Value?.ToString();
            dta.V0RELAT_PERI_FINAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}