using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Auto.DB2.AU0025S
{
    public class M_010_000_SELECIONA_TAXAS_DB_SELECT_2_Query1 : QueryBasis<M_010_000_SELECIONA_TAXAS_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            PRMREF_IX, TAXA_IS,
            CODUNIMO
            INTO
            :TAXAC-PRMREF-IX, :TAXAC-TAXA-IS,
            :TAXAC-CODUNIMO
            FROM SEGUROS.V1AUTOCONVTAXA
            WHERE
            COD_EMPRESA = 0
            AND REGIAO = :TAXAC-REGIAO
            AND CODPRODU = :TAXAC-CODPRODU
            AND CODAGRUPA = :TAXAC-CODAGRUPA
            AND ANOVEICL = :TAXAC-ANOVEICL
            AND DTINIVIG <= :TAXAC-DTINIVIG
            AND DTTERVIG >= :TAXAC-DTINIVIG
            AND VERSAO < 203
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											PRMREF_IX
							, TAXA_IS
							,
											CODUNIMO
											FROM SEGUROS.V1AUTOCONVTAXA
											WHERE
											COD_EMPRESA = 0
											AND REGIAO = '{this.TAXAC_REGIAO}'
											AND CODPRODU = '{this.TAXAC_CODPRODU}'
											AND CODAGRUPA = '{this.TAXAC_CODAGRUPA}'
											AND ANOVEICL = '{this.TAXAC_ANOVEICL}'
											AND DTINIVIG <= '{this.TAXAC_DTINIVIG}'
											AND DTTERVIG >= '{this.TAXAC_DTINIVIG}'
											AND VERSAO < 203";

            return query;
        }
        public string TAXAC_PRMREF_IX { get; set; }
        public string TAXAC_TAXA_IS { get; set; }
        public string TAXAC_CODUNIMO { get; set; }
        public string TAXAC_CODAGRUPA { get; set; }
        public string TAXAC_CODPRODU { get; set; }
        public string TAXAC_ANOVEICL { get; set; }
        public string TAXAC_DTINIVIG { get; set; }
        public string TAXAC_REGIAO { get; set; }

        public static M_010_000_SELECIONA_TAXAS_DB_SELECT_2_Query1 Execute(M_010_000_SELECIONA_TAXAS_DB_SELECT_2_Query1 m_010_000_SELECIONA_TAXAS_DB_SELECT_2_Query1)
        {
            var ths = m_010_000_SELECIONA_TAXAS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_010_000_SELECIONA_TAXAS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_010_000_SELECIONA_TAXAS_DB_SELECT_2_Query1();
            var i = 0;
            dta.TAXAC_PRMREF_IX = result[i++].Value?.ToString();
            dta.TAXAC_TAXA_IS = result[i++].Value?.ToString();
            dta.TAXAC_CODUNIMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}