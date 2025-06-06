using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Auto.DB2.AU0032S
{
    public class M_020_000_PESQ_TATTXACE_DB_SELECT_1_Query1 : QueryBasis<M_020_000_PESQ_TATTXACE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT TAXACARR,
            TAXAOUTR,
            TAXAEQUIP,
            TAXAREINT
            INTO
            :TXACE-TAXACARR,
            :TXACE-TAXAOUTR,
            :TXACE-TAXAEQUIP,
            :TXACE-TAXAREINT
            FROM SEGUROS.V1TAXACESS
            WHERE CODTAB = :TXACE-CODTAB
            AND CODPRODU = 0
            AND CDACESS = 0
            AND CATTARIF = :TXACE-CATTARIF
            AND TIPOCOB = :TXACE-TIPOCOB
            AND FRANQFAC = :TXACE-FRANQFAC
            AND REGIAO = :TXACE-REGIAO
            AND DTINIVIG <= :TXACE-DTINIVIG
            AND DTTERVIG >= :TXACE-DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TAXACARR
							,
											TAXAOUTR
							,
											TAXAEQUIP
							,
											TAXAREINT
											FROM SEGUROS.V1TAXACESS
											WHERE CODTAB = '{this.TXACE_CODTAB}'
											AND CODPRODU = 0
											AND CDACESS = 0
											AND CATTARIF = '{this.TXACE_CATTARIF}'
											AND TIPOCOB = '{this.TXACE_TIPOCOB}'
											AND FRANQFAC = '{this.TXACE_FRANQFAC}'
											AND REGIAO = '{this.TXACE_REGIAO}'
											AND DTINIVIG <= '{this.TXACE_DTINIVIG}'
											AND DTTERVIG >= '{this.TXACE_DTINIVIG}'";

            return query;
        }
        public string TXACE_TAXACARR { get; set; }
        public string TXACE_TAXAOUTR { get; set; }
        public string TXACE_TAXAEQUIP { get; set; }
        public string TXACE_TAXAREINT { get; set; }
        public string TXACE_CATTARIF { get; set; }
        public string TXACE_FRANQFAC { get; set; }
        public string TXACE_DTINIVIG { get; set; }
        public string TXACE_TIPOCOB { get; set; }
        public string TXACE_CODTAB { get; set; }
        public string TXACE_REGIAO { get; set; }

        public static M_020_000_PESQ_TATTXACE_DB_SELECT_1_Query1 Execute(M_020_000_PESQ_TATTXACE_DB_SELECT_1_Query1 m_020_000_PESQ_TATTXACE_DB_SELECT_1_Query1)
        {
            var ths = m_020_000_PESQ_TATTXACE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_020_000_PESQ_TATTXACE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_020_000_PESQ_TATTXACE_DB_SELECT_1_Query1();
            var i = 0;
            dta.TXACE_TAXACARR = result[i++].Value?.ToString();
            dta.TXACE_TAXAOUTR = result[i++].Value?.ToString();
            dta.TXACE_TAXAEQUIP = result[i++].Value?.ToString();
            dta.TXACE_TAXAREINT = result[i++].Value?.ToString();
            return dta;
        }

    }
}