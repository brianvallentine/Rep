using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1471B
{
    public class M_0000_PRINCIPAL_DB_SELECT_3_Query1 : QueryBasis<M_0000_PRINCIPAL_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ANO_REFERENCIA,
            NUM_ARQUIVO
            INTO :CONARQEA-ANO-REFERENCIA,
            :CONARQEA-NUM-ARQUIVO
            FROM SEGUROS.CONT_ARQUIVOS_EA
            WHERE NSAS = :CONARQEA-NSAS
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT ANO_REFERENCIA
							,
											NUM_ARQUIVO
											FROM SEGUROS.CONT_ARQUIVOS_EA
											WHERE NSAS = '{this.CONARQEA_NSAS}'";

            return query;
        }
        public string CONARQEA_ANO_REFERENCIA { get; set; }
        public string CONARQEA_NUM_ARQUIVO { get; set; }
        public string CONARQEA_NSAS { get; set; }

        public static M_0000_PRINCIPAL_DB_SELECT_3_Query1 Execute(M_0000_PRINCIPAL_DB_SELECT_3_Query1 m_0000_PRINCIPAL_DB_SELECT_3_Query1)
        {
            var ths = m_0000_PRINCIPAL_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_PRINCIPAL_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_PRINCIPAL_DB_SELECT_3_Query1();
            var i = 0;
            dta.CONARQEA_ANO_REFERENCIA = result[i++].Value?.ToString();
            dta.CONARQEA_NUM_ARQUIVO = result[i++].Value?.ToString();
            return dta;
        }

    }
}