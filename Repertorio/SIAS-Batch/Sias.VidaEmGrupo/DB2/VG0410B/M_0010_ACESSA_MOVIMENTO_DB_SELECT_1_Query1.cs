using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0410B
{
    public class M_0010_ACESSA_MOVIMENTO_DB_SELECT_1_Query1 : QueryBasis<M_0010_ACESSA_MOVIMENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ESTR_EMISS,
            ORIG_PRODU
            INTO :PRDVG-ESTR-EMISS:PRDVG-ESTR-EMISS-W,
            :PRDVG-ORIG-PRODU
            FROM SEGUROS.PRODUTOS_VG
            WHERE NUM_APOLICE = :MOVTO-NUM-APOLICE
            AND COD_SUBGRUPO = :MOVTO-COD-SUBES
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ESTR_EMISS
							,
											ORIG_PRODU
											FROM SEGUROS.PRODUTOS_VG
											WHERE NUM_APOLICE = '{this.MOVTO_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.MOVTO_COD_SUBES}'
											WITH UR";

            return query;
        }
        public string PRDVG_ESTR_EMISS { get; set; }
        public string PRDVG_ESTR_EMISS_W { get; set; }
        public string PRDVG_ORIG_PRODU { get; set; }
        public string MOVTO_NUM_APOLICE { get; set; }
        public string MOVTO_COD_SUBES { get; set; }

        public static M_0010_ACESSA_MOVIMENTO_DB_SELECT_1_Query1 Execute(M_0010_ACESSA_MOVIMENTO_DB_SELECT_1_Query1 m_0010_ACESSA_MOVIMENTO_DB_SELECT_1_Query1)
        {
            var ths = m_0010_ACESSA_MOVIMENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0010_ACESSA_MOVIMENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0010_ACESSA_MOVIMENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRDVG_ESTR_EMISS = result[i++].Value?.ToString();
            dta.PRDVG_ESTR_EMISS_W = string.IsNullOrWhiteSpace(dta.PRDVG_ESTR_EMISS) ? "-1" : "0";
            dta.PRDVG_ORIG_PRODU = result[i++].Value?.ToString();
            return dta;
        }

    }
}