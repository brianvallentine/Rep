using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0118B
{
    public class M_1000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1 : QueryBasis<M_1000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            CODSUBES
            INTO :RELATO-NUM-APOLICE,
            :RELATO-CODSUBES
            FROM SEGUROS.COBRANCA_MENS_VGAP
            WHERE IDFORM = 'A4'
            AND NUM_APOLICE = :PROPVA-NUM-APOLICE
            AND CODSUBES = :PROPVA-CODSUBES
            AND COD_OPERACAO = 2
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											CODSUBES
											FROM SEGUROS.COBRANCA_MENS_VGAP
											WHERE IDFORM = 'A4'
											AND NUM_APOLICE = '{this.PROPVA_NUM_APOLICE}'
											AND CODSUBES = '{this.PROPVA_CODSUBES}'
											AND COD_OPERACAO = 2";

            return query;
        }
        public string RELATO_NUM_APOLICE { get; set; }
        public string RELATO_CODSUBES { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_CODSUBES { get; set; }

        public static M_1000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1 Execute(M_1000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1 m_1000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1)
        {
            var ths = m_1000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1();
            var i = 0;
            dta.RELATO_NUM_APOLICE = result[i++].Value?.ToString();
            dta.RELATO_CODSUBES = result[i++].Value?.ToString();
            return dta;
        }

    }
}