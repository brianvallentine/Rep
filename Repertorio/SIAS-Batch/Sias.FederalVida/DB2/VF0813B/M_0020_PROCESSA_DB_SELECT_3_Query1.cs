using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0813B
{
    public class M_0020_PROCESSA_DB_SELECT_3_Query1 : QueryBasis<M_0020_PROCESSA_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.CODCLIEN,
            A.NUM_APOLICE,
            A.CODSUBES,
            A.FONTE,
            A.SITUACAO,
            A.CODPRODU,
            B.TEM_SAF,
            B.TEM_CDG
            INTO :V0PROP-CODCLIEN,
            :V0PROP-NUM-APOLICE,
            :V0PROP-CODSUBES,
            :V0PROP-FONTE,
            :V0PROP-SITUACAO,
            :V0PROP-CODPRODU,
            :V0PRVG-TEM-SAF:VIND-TEM-SAF,
            :V0PRVG-TEM-CDG:VIND-TEM-CDG
            FROM SEGUROS.V0PROPOSTAVA A,
            SEGUROS.V0PRODUTOSVG B
            WHERE A.NRCERTIF = :V0HCTA-NRCERTIF
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.CODSUBES = A.CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.CODCLIEN
							,
											A.NUM_APOLICE
							,
											A.CODSUBES
							,
											A.FONTE
							,
											A.SITUACAO
							,
											A.CODPRODU
							,
											B.TEM_SAF
							,
											B.TEM_CDG
											FROM SEGUROS.V0PROPOSTAVA A
							,
											SEGUROS.V0PRODUTOSVG B
											WHERE A.NRCERTIF = '{this.V0HCTA_NRCERTIF}'
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.CODSUBES = A.CODSUBES";

            return query;
        }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0PROP_CODSUBES { get; set; }
        public string V0PROP_FONTE { get; set; }
        public string V0PROP_SITUACAO { get; set; }
        public string V0PROP_CODPRODU { get; set; }
        public string V0PRVG_TEM_SAF { get; set; }
        public string VIND_TEM_SAF { get; set; }
        public string V0PRVG_TEM_CDG { get; set; }
        public string VIND_TEM_CDG { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }

        public static M_0020_PROCESSA_DB_SELECT_3_Query1 Execute(M_0020_PROCESSA_DB_SELECT_3_Query1 m_0020_PROCESSA_DB_SELECT_3_Query1)
        {
            var ths = m_0020_PROCESSA_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0020_PROCESSA_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0020_PROCESSA_DB_SELECT_3_Query1();
            var i = 0;
            dta.V0PROP_CODCLIEN = result[i++].Value?.ToString();
            dta.V0PROP_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0PROP_CODSUBES = result[i++].Value?.ToString();
            dta.V0PROP_FONTE = result[i++].Value?.ToString();
            dta.V0PROP_SITUACAO = result[i++].Value?.ToString();
            dta.V0PROP_CODPRODU = result[i++].Value?.ToString();
            dta.V0PRVG_TEM_SAF = result[i++].Value?.ToString();
            dta.VIND_TEM_SAF = string.IsNullOrWhiteSpace(dta.V0PRVG_TEM_SAF) ? "-1" : "0";
            dta.V0PRVG_TEM_CDG = result[i++].Value?.ToString();
            dta.VIND_TEM_CDG = string.IsNullOrWhiteSpace(dta.V0PRVG_TEM_CDG) ? "-1" : "0";
            return dta;
        }

    }
}