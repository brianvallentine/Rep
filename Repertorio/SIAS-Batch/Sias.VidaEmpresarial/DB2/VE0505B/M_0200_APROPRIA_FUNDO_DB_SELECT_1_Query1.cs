using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0505B
{
    public class M_0200_APROPRIA_FUNDO_DB_SELECT_1_Query1 : QueryBasis<M_0200_APROPRIA_FUNDO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLBASVG,
            VALBASAP,
            VLCOMISVG,
            VLCOMISAP,
            PCCOMIND,
            PCCOMGER,
            PCCOMSUP
            INTO :VALBASVG,
            :VALBASAP,
            :VLCOMISVG,
            :VLCOMISAP,
            :PCCOMIND,
            :PCCOMGER,
            :PCCOMSUP
            FROM SEGUROS.V0FUNDOCOMISVA
            WHERE NUM_TERMO = :NRTERMO
            AND CODOPER = :CODOPER
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLBASVG
							,
											VALBASAP
							,
											VLCOMISVG
							,
											VLCOMISAP
							,
											PCCOMIND
							,
											PCCOMGER
							,
											PCCOMSUP
											FROM SEGUROS.V0FUNDOCOMISVA
											WHERE NUM_TERMO = '{this.NRTERMO}'
											AND CODOPER = '{this.CODOPER}'";

            return query;
        }
        public string VALBASVG { get; set; }
        public string VALBASAP { get; set; }
        public string VLCOMISVG { get; set; }
        public string VLCOMISAP { get; set; }
        public string PCCOMIND { get; set; }
        public string PCCOMGER { get; set; }
        public string PCCOMSUP { get; set; }
        public string NRTERMO { get; set; }
        public string CODOPER { get; set; }

        public static M_0200_APROPRIA_FUNDO_DB_SELECT_1_Query1 Execute(M_0200_APROPRIA_FUNDO_DB_SELECT_1_Query1 m_0200_APROPRIA_FUNDO_DB_SELECT_1_Query1)
        {
            var ths = m_0200_APROPRIA_FUNDO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0200_APROPRIA_FUNDO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0200_APROPRIA_FUNDO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VALBASVG = result[i++].Value?.ToString();
            dta.VALBASAP = result[i++].Value?.ToString();
            dta.VLCOMISVG = result[i++].Value?.ToString();
            dta.VLCOMISAP = result[i++].Value?.ToString();
            dta.PCCOMIND = result[i++].Value?.ToString();
            dta.PCCOMGER = result[i++].Value?.ToString();
            dta.PCCOMSUP = result[i++].Value?.ToString();
            return dta;
        }

    }
}