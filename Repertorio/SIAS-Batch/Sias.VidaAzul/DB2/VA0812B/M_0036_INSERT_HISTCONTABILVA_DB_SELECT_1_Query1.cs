using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0812B
{
    public class M_0036_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1 : QueryBasis<M_0036_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_APOLICE,
            A.CODSUBES,
            A.FONTE,
            A.DTVENCTO,
            A.OCORHIST,
            A.DTQITBCO,
            A.CODCLIEN,
            A.OPCAO_COBER,
            B.RAMO_EMISSOR
            INTO :PROP-NUM-APOLICE,
            :PROP-CODSUBES,
            :PROP-FONTE,
            :PROP-DTVENCTO,
            :PROP-OCORHIST,
            :PROP-DTQITBCO,
            :PROP-CODCLIEN,
            :PROP-OPCAO-COBER,
            :PROP-RAMO
            FROM SEGUROS.V0PROPOSTAVA A,
            SEGUROS.APOLICES B
            WHERE A.NRCERTIF = :HCTA-NRCERTIF
            AND A.NUM_APOLICE = B.NUM_APOLICE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_APOLICE
							,
											A.CODSUBES
							,
											A.FONTE
							,
											A.DTVENCTO
							,
											A.OCORHIST
							,
											A.DTQITBCO
							,
											A.CODCLIEN
							,
											A.OPCAO_COBER
							,
											B.RAMO_EMISSOR
											FROM SEGUROS.V0PROPOSTAVA A
							,
											SEGUROS.APOLICES B
											WHERE A.NRCERTIF = '{this.HCTA_NRCERTIF}'
											AND A.NUM_APOLICE = B.NUM_APOLICE
											WITH UR";

            return query;
        }
        public string PROP_NUM_APOLICE { get; set; }
        public string PROP_CODSUBES { get; set; }
        public string PROP_FONTE { get; set; }
        public string PROP_DTVENCTO { get; set; }
        public string PROP_OCORHIST { get; set; }
        public string PROP_DTQITBCO { get; set; }
        public string PROP_CODCLIEN { get; set; }
        public string PROP_OPCAO_COBER { get; set; }
        public string PROP_RAMO { get; set; }
        public string HCTA_NRCERTIF { get; set; }

        public static M_0036_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1 Execute(M_0036_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1 m_0036_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1)
        {
            var ths = m_0036_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0036_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0036_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROP_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROP_CODSUBES = result[i++].Value?.ToString();
            dta.PROP_FONTE = result[i++].Value?.ToString();
            dta.PROP_DTVENCTO = result[i++].Value?.ToString();
            dta.PROP_OCORHIST = result[i++].Value?.ToString();
            dta.PROP_DTQITBCO = result[i++].Value?.ToString();
            dta.PROP_CODCLIEN = result[i++].Value?.ToString();
            dta.PROP_OPCAO_COBER = result[i++].Value?.ToString();
            dta.PROP_RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}