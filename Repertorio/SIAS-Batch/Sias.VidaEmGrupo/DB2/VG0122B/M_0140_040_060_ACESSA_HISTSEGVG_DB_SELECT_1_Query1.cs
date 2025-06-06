using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0122B
{
    public class M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1 : QueryBasis<M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT NUM_APOLICE ,
            NUM_ITEM ,
            COD_OPERACAO ,
            DATA_MOVIMENTO ,
            OCORR_HISTORICO ,
            COD_MOEDA_IMP ,
            COD_MOEDA_PRM
            INTO :HISTSEGVG-NUM-APOL ,
            :HISTSEGVG-NUM-ITEM ,
            :HISTSEGVG-COD-OPER ,
            :HISTSEGVG-DATA-MOV ,
            :HISTSEGVG-OCORR-HI ,
            :HISTSEGVG-COD-MOEDA-IMP ,
            :HISTSEGVG-COD-MOEDA-PRM
            FROM SEGUROS.V1HISTSEGVG
            WHERE NUM_APOLICE = :SEGURAVG-NUM-APOL
            AND NUM_ITEM = :SEGURAVG-NUM-ITEM
            AND OCORR_HISTORICO = :SEGURAVG-OCORR-HI
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE 
							,
											NUM_ITEM 
							,
											COD_OPERACAO 
							,
											DATA_MOVIMENTO 
							,
											OCORR_HISTORICO 
							,
											COD_MOEDA_IMP 
							,
											COD_MOEDA_PRM
											FROM SEGUROS.V1HISTSEGVG
											WHERE NUM_APOLICE = '{this.SEGURAVG_NUM_APOL}'
											AND NUM_ITEM = '{this.SEGURAVG_NUM_ITEM}'
											AND OCORR_HISTORICO = '{this.SEGURAVG_OCORR_HI}'";

            return query;
        }
        public string HISTSEGVG_NUM_APOL { get; set; }
        public string HISTSEGVG_NUM_ITEM { get; set; }
        public string HISTSEGVG_COD_OPER { get; set; }
        public string HISTSEGVG_DATA_MOV { get; set; }
        public string HISTSEGVG_OCORR_HI { get; set; }
        public string HISTSEGVG_COD_MOEDA_IMP { get; set; }
        public string HISTSEGVG_COD_MOEDA_PRM { get; set; }
        public string SEGURAVG_NUM_APOL { get; set; }
        public string SEGURAVG_NUM_ITEM { get; set; }
        public string SEGURAVG_OCORR_HI { get; set; }

        public static M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1 Execute(M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1 m_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1)
        {
            var ths = m_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISTSEGVG_NUM_APOL = result[i++].Value?.ToString();
            dta.HISTSEGVG_NUM_ITEM = result[i++].Value?.ToString();
            dta.HISTSEGVG_COD_OPER = result[i++].Value?.ToString();
            dta.HISTSEGVG_DATA_MOV = result[i++].Value?.ToString();
            dta.HISTSEGVG_OCORR_HI = result[i++].Value?.ToString();
            dta.HISTSEGVG_COD_MOEDA_IMP = result[i++].Value?.ToString();
            dta.HISTSEGVG_COD_MOEDA_PRM = result[i++].Value?.ToString();
            return dta;
        }

    }
}