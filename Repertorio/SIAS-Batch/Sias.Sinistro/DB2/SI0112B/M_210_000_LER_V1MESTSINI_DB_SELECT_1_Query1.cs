using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0112B
{
    public class M_210_000_LER_V1MESTSINI_DB_SELECT_1_Query1 : QueryBasis<M_210_000_LER_V1MESTSINI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE, NRENDOS,
            NUM_APOL_SINISTRO, DATCMD,
            DATORR, NRCERTIF,
            COD_MOEDA_SINI, IDTPSEGU,
            NUMIRB, CODSUBES,
            NREMBARQ, REFEMBQ,
            VALSEGBT, PCPARTIC
            INTO :MEST-NUM-APOL, :MEST-NRENDOS,
            :MEST-APOL-SINI, :MEST-DATCMD,
            :MEST-DATORR, :MEST-NRCERTIF,
            :MEST-MOEDA-SINI, :MEST-IDTPSEGU,
            :MEST-NUMIRB, :MEST-CODSUBES,
            :MEST-NREMBARQ, :MEST-REFEMBQ,
            :MEST-VALSEGBT, :MEST-PCPARTIC
            FROM SEGUROS.V1MESTSINI
            WHERE NUM_APOL_SINISTRO = :V1RELA-NUMSINI
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							, NRENDOS
							,
											NUM_APOL_SINISTRO
							, DATCMD
							,
											DATORR
							, NRCERTIF
							,
											COD_MOEDA_SINI
							, IDTPSEGU
							,
											NUMIRB
							, CODSUBES
							,
											NREMBARQ
							, REFEMBQ
							,
											VALSEGBT
							, PCPARTIC
											FROM SEGUROS.V1MESTSINI
											WHERE NUM_APOL_SINISTRO = '{this.V1RELA_NUMSINI}'";

            return query;
        }
        public string MEST_NUM_APOL { get; set; }
        public string MEST_NRENDOS { get; set; }
        public string MEST_APOL_SINI { get; set; }
        public string MEST_DATCMD { get; set; }
        public string MEST_DATORR { get; set; }
        public string MEST_NRCERTIF { get; set; }
        public string MEST_MOEDA_SINI { get; set; }
        public string MEST_IDTPSEGU { get; set; }
        public string MEST_NUMIRB { get; set; }
        public string MEST_CODSUBES { get; set; }
        public string MEST_NREMBARQ { get; set; }
        public string MEST_REFEMBQ { get; set; }
        public string MEST_VALSEGBT { get; set; }
        public string MEST_PCPARTIC { get; set; }
        public string V1RELA_NUMSINI { get; set; }

        public static M_210_000_LER_V1MESTSINI_DB_SELECT_1_Query1 Execute(M_210_000_LER_V1MESTSINI_DB_SELECT_1_Query1 m_210_000_LER_V1MESTSINI_DB_SELECT_1_Query1)
        {
            var ths = m_210_000_LER_V1MESTSINI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_210_000_LER_V1MESTSINI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_210_000_LER_V1MESTSINI_DB_SELECT_1_Query1();
            var i = 0;
            dta.MEST_NUM_APOL = result[i++].Value?.ToString();
            dta.MEST_NRENDOS = result[i++].Value?.ToString();
            dta.MEST_APOL_SINI = result[i++].Value?.ToString();
            dta.MEST_DATCMD = result[i++].Value?.ToString();
            dta.MEST_DATORR = result[i++].Value?.ToString();
            dta.MEST_NRCERTIF = result[i++].Value?.ToString();
            dta.MEST_MOEDA_SINI = result[i++].Value?.ToString();
            dta.MEST_IDTPSEGU = result[i++].Value?.ToString();
            dta.MEST_NUMIRB = result[i++].Value?.ToString();
            dta.MEST_CODSUBES = result[i++].Value?.ToString();
            dta.MEST_NREMBARQ = result[i++].Value?.ToString();
            dta.MEST_REFEMBQ = result[i++].Value?.ToString();
            dta.MEST_VALSEGBT = result[i++].Value?.ToString();
            dta.MEST_PCPARTIC = result[i++].Value?.ToString();
            return dta;
        }

    }
}