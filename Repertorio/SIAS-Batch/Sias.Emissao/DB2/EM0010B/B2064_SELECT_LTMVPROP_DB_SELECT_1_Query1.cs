using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class B2064_SELECT_LTMVPROP_DB_SELECT_1_Query1 : QueryBasis<B2064_SELECT_LTMVPROP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_MOVIMENTO ,
            VLR_JUROS_MENSAL ,
            VLR_CUSTO_APOLICE ,
            NUM_CLASSE_ADESAO ,
            IND_REGIAO ,
            VALUE(PCT_DESC_AGRUP,0) ,
            VALUE(PCT_DESC_FIDEL,0) ,
            VALUE(PCT_DESC_EXP,0) ,
            VALUE(PCT_DESC_EQUIP,0) ,
            VALUE(PCT_DESC_BLINDAGEM,0)
            INTO :LTMVPROP-COD-MOVIMENTO ,
            :LTMVPROP-VLR-JUROS-MENSAL ,
            :LTMVPROP-VLR-CUSTO-APOLICE ,
            :LTMVPROP-NUM-CLASSE-ADESAO ,
            :LTMVPROP-IND-REGIAO ,
            :LTMVPROP-PCT-DESC-AGRUP ,
            :LTMVPROP-PCT-DESC-FIDEL ,
            :LTMVPROP-PCT-DESC-EXP ,
            :LTMVPROP-PCT-DESC-EQUIP ,
            :LTMVPROP-PCT-DESC-BLINDAGEM
            FROM SEGUROS.LT_MOV_PROPOSTA
            WHERE NUM_APOLICE = :ENDO-NUM-APOLICE
            AND NUM_ENDOSSO = :ENDO-NRENDOS
            AND COD_MOVIMENTO IN ( 'A' , 'C' , 'T' )
            AND SIT_MOVIMENTO = '1'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_MOVIMENTO 
							,
											VLR_JUROS_MENSAL 
							,
											VLR_CUSTO_APOLICE 
							,
											NUM_CLASSE_ADESAO 
							,
											IND_REGIAO 
							,
											VALUE(PCT_DESC_AGRUP
							,0) 
							,
											VALUE(PCT_DESC_FIDEL
							,0) 
							,
											VALUE(PCT_DESC_EXP
							,0) 
							,
											VALUE(PCT_DESC_EQUIP
							,0) 
							,
											VALUE(PCT_DESC_BLINDAGEM
							,0)
											FROM SEGUROS.LT_MOV_PROPOSTA
											WHERE NUM_APOLICE = '{this.ENDO_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.ENDO_NRENDOS}'
											AND COD_MOVIMENTO IN ( 'A' 
							, 'C' 
							, 'T' )
											AND SIT_MOVIMENTO = '1'
											WITH UR";

            return query;
        }
        public string LTMVPROP_COD_MOVIMENTO { get; set; }
        public string LTMVPROP_VLR_JUROS_MENSAL { get; set; }
        public string LTMVPROP_VLR_CUSTO_APOLICE { get; set; }
        public string LTMVPROP_NUM_CLASSE_ADESAO { get; set; }
        public string LTMVPROP_IND_REGIAO { get; set; }
        public string LTMVPROP_PCT_DESC_AGRUP { get; set; }
        public string LTMVPROP_PCT_DESC_FIDEL { get; set; }
        public string LTMVPROP_PCT_DESC_EXP { get; set; }
        public string LTMVPROP_PCT_DESC_EQUIP { get; set; }
        public string LTMVPROP_PCT_DESC_BLINDAGEM { get; set; }
        public string ENDO_NUM_APOLICE { get; set; }
        public string ENDO_NRENDOS { get; set; }

        public static B2064_SELECT_LTMVPROP_DB_SELECT_1_Query1 Execute(B2064_SELECT_LTMVPROP_DB_SELECT_1_Query1 b2064_SELECT_LTMVPROP_DB_SELECT_1_Query1)
        {
            var ths = b2064_SELECT_LTMVPROP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B2064_SELECT_LTMVPROP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B2064_SELECT_LTMVPROP_DB_SELECT_1_Query1();
            var i = 0;
            dta.LTMVPROP_COD_MOVIMENTO = result[i++].Value?.ToString();
            dta.LTMVPROP_VLR_JUROS_MENSAL = result[i++].Value?.ToString();
            dta.LTMVPROP_VLR_CUSTO_APOLICE = result[i++].Value?.ToString();
            dta.LTMVPROP_NUM_CLASSE_ADESAO = result[i++].Value?.ToString();
            dta.LTMVPROP_IND_REGIAO = result[i++].Value?.ToString();
            dta.LTMVPROP_PCT_DESC_AGRUP = result[i++].Value?.ToString();
            dta.LTMVPROP_PCT_DESC_FIDEL = result[i++].Value?.ToString();
            dta.LTMVPROP_PCT_DESC_EXP = result[i++].Value?.ToString();
            dta.LTMVPROP_PCT_DESC_EQUIP = result[i++].Value?.ToString();
            dta.LTMVPROP_PCT_DESC_BLINDAGEM = result[i++].Value?.ToString();
            return dta;
        }

    }
}