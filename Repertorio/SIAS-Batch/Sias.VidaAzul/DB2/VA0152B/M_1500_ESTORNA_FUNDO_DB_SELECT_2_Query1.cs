using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0152B
{
    public class M_1500_ESTORNA_FUNDO_DB_SELECT_2_Query1 : QueryBasis<M_1500_ESTORNA_FUNDO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODPRODU,
            FONTE,
            AGENCIA,
            CODCLIEN,
            NRMATRVEN,
            VLBASVG,
            VALBASAP,
            VLCOMISVG,
            VLCOMISAP,
            DTQITBCO,
            PCCOMIND,
            PCCOMGER,
            PCCOMSUP
            INTO :CODPRODU,
            :FONTE,
            :AGENCIA,
            :CODCLIEN,
            :NRMATRVEN,
            :VALBASVG,
            :VALBASAP,
            :VLCOMISVG,
            :VLCOMISAP,
            :DTQITBCO,
            :PCCOMIND,
            :PCCOMGER,
            :PCCOMSUP
            FROM SEGUROS.V0FUNDOCOMISVA
            WHERE NRCERTIF = :NRCERTIF
            AND CODOPER = 1101
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODPRODU
							,
											FONTE
							,
											AGENCIA
							,
											CODCLIEN
							,
											NRMATRVEN
							,
											VLBASVG
							,
											VALBASAP
							,
											VLCOMISVG
							,
											VLCOMISAP
							,
											DTQITBCO
							,
											PCCOMIND
							,
											PCCOMGER
							,
											PCCOMSUP
											FROM SEGUROS.V0FUNDOCOMISVA
											WHERE NRCERTIF = '{this.NRCERTIF}'
											AND CODOPER = 1101";

            return query;
        }
        public string CODPRODU { get; set; }
        public string FONTE { get; set; }
        public string AGENCIA { get; set; }
        public string CODCLIEN { get; set; }
        public string NRMATRVEN { get; set; }
        public string VALBASVG { get; set; }
        public string VALBASAP { get; set; }
        public string VLCOMISVG { get; set; }
        public string VLCOMISAP { get; set; }
        public string DTQITBCO { get; set; }
        public string PCCOMIND { get; set; }
        public string PCCOMGER { get; set; }
        public string PCCOMSUP { get; set; }
        public string NRCERTIF { get; set; }

        public static M_1500_ESTORNA_FUNDO_DB_SELECT_2_Query1 Execute(M_1500_ESTORNA_FUNDO_DB_SELECT_2_Query1 m_1500_ESTORNA_FUNDO_DB_SELECT_2_Query1)
        {
            var ths = m_1500_ESTORNA_FUNDO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1500_ESTORNA_FUNDO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1500_ESTORNA_FUNDO_DB_SELECT_2_Query1();
            var i = 0;
            dta.CODPRODU = result[i++].Value?.ToString();
            dta.FONTE = result[i++].Value?.ToString();
            dta.AGENCIA = result[i++].Value?.ToString();
            dta.CODCLIEN = result[i++].Value?.ToString();
            dta.NRMATRVEN = result[i++].Value?.ToString();
            dta.VALBASVG = result[i++].Value?.ToString();
            dta.VALBASAP = result[i++].Value?.ToString();
            dta.VLCOMISVG = result[i++].Value?.ToString();
            dta.VLCOMISAP = result[i++].Value?.ToString();
            dta.DTQITBCO = result[i++].Value?.ToString();
            dta.PCCOMIND = result[i++].Value?.ToString();
            dta.PCCOMGER = result[i++].Value?.ToString();
            dta.PCCOMSUP = result[i++].Value?.ToString();
            return dta;
        }

    }
}