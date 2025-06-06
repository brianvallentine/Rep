using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9211B
{
    public class R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_1_Query1 : QueryBasis<R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE ,
            NUM_ENDOSSO ,
            NUM_PARCELA ,
            COD_CONVENIO ,
            NSAS ,
            COD_AGENCIA ,
            COD_BANCO ,
            NUM_CONTA_CNB ,
            NUM_DV_CONTA_CNB ,
            IND_CONTA_BANCARIA
            INTO :GE369-NUM-APOLICE ,
            :GE369-NUM-ENDOSSO ,
            :GE369-NUM-PARCELA ,
            :GE369-COD-CONVENIO ,
            :GE369-NSAS ,
            :GE369-COD-AGENCIA ,
            :GE369-COD-BANCO ,
            :GE369-NUM-CONTA-CNB ,
            :GE369-NUM-DV-CONTA-CNB ,
            :GE369-IND-CONTA-BANCARIA
            FROM SEGUROS.GE_MOVTO_CONTA
            WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE
            AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO
            AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE 
							,
											NUM_ENDOSSO 
							,
											NUM_PARCELA 
							,
											COD_CONVENIO 
							,
											NSAS 
							,
											COD_AGENCIA 
							,
											COD_BANCO 
							,
											NUM_CONTA_CNB 
							,
											NUM_DV_CONTA_CNB 
							,
											IND_CONTA_BANCARIA
											FROM SEGUROS.GE_MOVTO_CONTA
											WHERE NUM_APOLICE = '{this.MOVDEBCE_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.MOVDEBCE_NUM_ENDOSSO}'
											AND NUM_PARCELA = '{this.MOVDEBCE_NUM_PARCELA}'";

            return query;
        }
        public string GE369_NUM_APOLICE { get; set; }
        public string GE369_NUM_ENDOSSO { get; set; }
        public string GE369_NUM_PARCELA { get; set; }
        public string GE369_COD_CONVENIO { get; set; }
        public string GE369_NSAS { get; set; }
        public string GE369_COD_AGENCIA { get; set; }
        public string GE369_COD_BANCO { get; set; }
        public string GE369_NUM_CONTA_CNB { get; set; }
        public string GE369_NUM_DV_CONTA_CNB { get; set; }
        public string GE369_IND_CONTA_BANCARIA { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }

        public static R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_1_Query1 Execute(R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_1_Query1 r1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_1_Query1)
        {
            var ths = r1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE369_NUM_APOLICE = result[i++].Value?.ToString();
            dta.GE369_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.GE369_NUM_PARCELA = result[i++].Value?.ToString();
            dta.GE369_COD_CONVENIO = result[i++].Value?.ToString();
            dta.GE369_NSAS = result[i++].Value?.ToString();
            dta.GE369_COD_AGENCIA = result[i++].Value?.ToString();
            dta.GE369_COD_BANCO = result[i++].Value?.ToString();
            dta.GE369_NUM_CONTA_CNB = result[i++].Value?.ToString();
            dta.GE369_NUM_DV_CONTA_CNB = result[i++].Value?.ToString();
            dta.GE369_IND_CONTA_BANCARIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}