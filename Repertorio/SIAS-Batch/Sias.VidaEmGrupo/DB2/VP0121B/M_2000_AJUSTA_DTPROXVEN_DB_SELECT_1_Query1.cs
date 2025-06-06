using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0121B
{
    public class M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1 : QueryBasis<M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TAXAVG,
            TAXAAP
            INTO :MTXVG,
            :MTXAPMA
            FROM SEGUROS.PLANOS_VA_VGAP
            WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE
            AND CODSUBES = :PROPVA-CODSUBES
            AND OPCAO_COBER = :PROPVA-OPCAO-COBER
            AND DTINIVIG <= :PROPVA-DTQITBCO
            AND DTTERVIG >= :PROPVA-DTQITBCO
            AND IDADE_INICIAL = 0
            AND IDADE_FINAL = 0
            AND PERIPGTO = :OPCAOP-PERIPGTO
            AND VLPREMIOTOT = :COBERP-VLPREMIO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TAXAVG
							,
											TAXAAP
											FROM SEGUROS.PLANOS_VA_VGAP
											WHERE NUM_APOLICE = '{this.PROPVA_NUM_APOLICE}'
											AND CODSUBES = '{this.PROPVA_CODSUBES}'
											AND OPCAO_COBER = '{this.PROPVA_OPCAO_COBER}'
											AND DTINIVIG <= '{this.PROPVA_DTQITBCO}'
											AND DTTERVIG >= '{this.PROPVA_DTQITBCO}'
											AND IDADE_INICIAL = 0
											AND IDADE_FINAL = 0
											AND PERIPGTO = '{this.OPCAOP_PERIPGTO}'
											AND VLPREMIOTOT = '{this.COBERP_VLPREMIO}'
											WITH UR";

            return query;
        }
        public string MTXVG { get; set; }
        public string MTXAPMA { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_OPCAO_COBER { get; set; }
        public string PROPVA_CODSUBES { get; set; }
        public string PROPVA_DTQITBCO { get; set; }
        public string OPCAOP_PERIPGTO { get; set; }
        public string COBERP_VLPREMIO { get; set; }

        public static M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1 Execute(M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1 m_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1)
        {
            var ths = m_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1();
            var i = 0;
            dta.MTXVG = result[i++].Value?.ToString();
            dta.MTXAPMA = result[i++].Value?.ToString();
            return dta;
        }

    }
}