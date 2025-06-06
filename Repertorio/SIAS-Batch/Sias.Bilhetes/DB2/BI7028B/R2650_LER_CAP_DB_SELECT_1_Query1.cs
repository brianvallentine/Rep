using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7028B
{
    public class R2650_LER_CAP_DB_SELECT_1_Query1 : QueryBasis<R2650_LER_CAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            CASE C.QTD_DIG_COMBINACAO
            WHEN 5 THEN
            SUBSTR (DIGITS (INTEGER(D.DES_COMBINACAO)), 6,5)
            WHEN 6 THEN
            SUBSTR (DIGITS (INTEGER(D.DES_COMBINACAO)), 5,6)
            WHEN 7 THEN
            SUBSTR (DIGITS (INTEGER(D.DES_COMBINACAO)), 4,7)
            WHEN 8 THEN
            SUBSTR (DIGITS (INTEGER(D.DES_COMBINACAO)), 3,8)
            WHEN 9 THEN
            SUBSTR (DIGITS (INTEGER(D.DES_COMBINACAO)), 2,9)
            END,
            E.COD_PROCESSO_SUSEP
            INTO :WS-CABU-SORTEIO-07,
            :CABU-COD-SUSEP-CAP
            FROM
            FDRCAP.FC_TITULO AS B,
            FDRCAP.FC_COMB_TITULOS AS D,
            FDRCAP.FC_PLANO AS C,
            FDRCAP.FC_PROCESSO_SUSEP AS E
            WHERE B.NUM_PROPOSTA = :WHOST-BILHETE
            AND B.COD_STA_TITULO = 'ATV'
            AND D.NUM_TITULO = B.NUM_TITULO
            AND D.NUM_COMBINACAO = 1
            AND D.IDE_SERIEPADRAO = B.IDE_SERIEPADRAO
            AND B.NUM_PLANO = C.NUM_PLANO
            AND C.NUM_PLANO = E.NUM_PLANO
            FETCH FIRST 01 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											CASE C.QTD_DIG_COMBINACAO
											WHEN 5 THEN
											SUBSTR (DIGITS (INTEGER(D.DES_COMBINACAO))
							, 6
							,5)
											WHEN 6 THEN
											SUBSTR (DIGITS (INTEGER(D.DES_COMBINACAO))
							, 5
							,6)
											WHEN 7 THEN
											SUBSTR (DIGITS (INTEGER(D.DES_COMBINACAO))
							, 4
							,7)
											WHEN 8 THEN
											SUBSTR (DIGITS (INTEGER(D.DES_COMBINACAO))
							, 3
							,8)
											WHEN 9 THEN
											SUBSTR (DIGITS (INTEGER(D.DES_COMBINACAO))
							, 2
							,9)
											END
							,
											E.COD_PROCESSO_SUSEP
											FROM
											FDRCAP.FC_TITULO AS B
							,
											FDRCAP.FC_COMB_TITULOS AS D
							,
											FDRCAP.FC_PLANO AS C
							,
											FDRCAP.FC_PROCESSO_SUSEP AS E
											WHERE B.NUM_PROPOSTA = '{this.WHOST_BILHETE}'
											AND B.COD_STA_TITULO = 'ATV'
											AND D.NUM_TITULO = B.NUM_TITULO
											AND D.NUM_COMBINACAO = 1
											AND D.IDE_SERIEPADRAO = B.IDE_SERIEPADRAO
											AND B.NUM_PLANO = C.NUM_PLANO
											AND C.NUM_PLANO = E.NUM_PLANO
											FETCH FIRST 01 ROWS ONLY
											WITH UR";

            return query;
        }
        public string WS_CABU_SORTEIO_07 { get; set; }
        public string CABU_COD_SUSEP_CAP { get; set; }
        public string WHOST_BILHETE { get; set; }

        public static R2650_LER_CAP_DB_SELECT_1_Query1 Execute(R2650_LER_CAP_DB_SELECT_1_Query1 r2650_LER_CAP_DB_SELECT_1_Query1)
        {
            var ths = r2650_LER_CAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2650_LER_CAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2650_LER_CAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_CABU_SORTEIO_07 = result[i++].Value?.ToString();
            dta.CABU_COD_SUSEP_CAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}