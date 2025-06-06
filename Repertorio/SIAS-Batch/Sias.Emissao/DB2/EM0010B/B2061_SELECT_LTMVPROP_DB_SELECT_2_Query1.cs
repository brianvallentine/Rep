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
    public class B2061_SELECT_LTMVPROP_DB_SELECT_2_Query1 : QueryBasis<B2061_SELECT_LTMVPROP_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_EXT_SEGURADO ,
            COD_CLASSE_ADESAO ,
            NUM_CLASSE_ADESAO ,
            COMPL_ENDER ,
            DT_INIVIG_PROPOSTA ,
            NUM_APOLICE ,
            QTD_PARCELAS ,
            VLR_JUROS_MENSAL ,
            VLR_CUSTO_APOLICE ,
            PCT_JUROS ,
            DATA_MOVIMENTO ,
            HORA_MOVIMENTO ,
            COD_MOVIMENTO ,
            SIT_MOVIMENTO ,
            COD_PRODUTO ,
            COD_EXT_ESTIP ,
            PCT_IOF ,
            CGCCPF ,
            VALUE(IND_REGIAO,0) ,
            VALUE(PCT_DESC_FIDEL,0) ,
            VALUE(PCT_DESC_EXP,0) ,
            VALUE(PCT_DESC_AGRUP,0) ,
            VALUE(PCT_DESC_EQUIP,0) ,
            VALUE(PCT_DESC_BLINDAGEM,0) ,
            VALUE(NUM_PROPOSTA_SIM,0) ,
            VALUE(IND_TIPO_VIGENCIA,0) ,
            VALUE(QTD_REN_SEM_SINI,0) ,
            VALUE(QTD_REN_SEM_SINI_INF,0)
            INTO :LTMVPROP-COD-EXT-SEGURADO ,
            :LTMVPROP-COD-CLASSE-ADESAO ,
            :LTMVPROP-NUM-CLASSE-ADESAO ,
            :LTMVPROP-COMPL-ENDER ,
            :LTMVPROP-DT-INIVIG-PROPOSTA ,
            :LTMVPROP-NUM-APOLICE ,
            :LTMVPROP-QTD-PARCELAS ,
            :LTMVPROP-VLR-JUROS-MENSAL ,
            :LTMVPROP-VLR-CUSTO-APOLICE ,
            :LTMVPROP-PCT-JUROS ,
            :LTMVPROP-DATA-MOVIMENTO ,
            :LTMVPROP-HORA-MOVIMENTO ,
            :LTMVPROP-COD-MOVIMENTO ,
            :LTMVPROP-SIT-MOVIMENTO ,
            :LTMVPROP-COD-PRODUTO ,
            :LTMVPROP-COD-EXT-ESTIP ,
            :LTMVPROP-PCT-IOF ,
            :LTMVPROP-CGCCPF ,
            :LTMVPROP-IND-REGIAO ,
            :LTMVPROP-PCT-DESC-FIDEL ,
            :LTMVPROP-PCT-DESC-EXP ,
            :LTMVPROP-PCT-DESC-AGRUP ,
            :LTMVPROP-PCT-DESC-EQUIP ,
            :LTMVPROP-PCT-DESC-BLINDAGEM ,
            :LTMVPROP-NUM-PROPOSTA-SIM ,
            :LTMVPROP-IND-TIPO-VIGENCIA ,
            :LTMVPROP-QTD-REN-SEM-SINI ,
            :LTMVPROP-QTD-REN-SEM-SINI-INF
            FROM SEGUROS.LT_MOV_PROPOSTA
            WHERE NUM_APOLICE = :ENDO-NUM-APOLICE
            AND SEQ_PROPOSTA = :LTMVPROP-SEQ-PROPOSTA
            AND COD_MOVIMENTO = '9'
            AND SIT_MOVIMENTO IN ( '1' , 'T' )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_EXT_SEGURADO 
							,
											COD_CLASSE_ADESAO 
							,
											NUM_CLASSE_ADESAO 
							,
											COMPL_ENDER 
							,
											DT_INIVIG_PROPOSTA 
							,
											NUM_APOLICE 
							,
											QTD_PARCELAS 
							,
											VLR_JUROS_MENSAL 
							,
											VLR_CUSTO_APOLICE 
							,
											PCT_JUROS 
							,
											DATA_MOVIMENTO 
							,
											HORA_MOVIMENTO 
							,
											COD_MOVIMENTO 
							,
											SIT_MOVIMENTO 
							,
											COD_PRODUTO 
							,
											COD_EXT_ESTIP 
							,
											PCT_IOF 
							,
											CGCCPF 
							,
											VALUE(IND_REGIAO
							,0) 
							,
											VALUE(PCT_DESC_FIDEL
							,0) 
							,
											VALUE(PCT_DESC_EXP
							,0) 
							,
											VALUE(PCT_DESC_AGRUP
							,0) 
							,
											VALUE(PCT_DESC_EQUIP
							,0) 
							,
											VALUE(PCT_DESC_BLINDAGEM
							,0) 
							,
											VALUE(NUM_PROPOSTA_SIM
							,0) 
							,
											VALUE(IND_TIPO_VIGENCIA
							,0) 
							,
											VALUE(QTD_REN_SEM_SINI
							,0) 
							,
											VALUE(QTD_REN_SEM_SINI_INF
							,0)
											FROM SEGUROS.LT_MOV_PROPOSTA
											WHERE NUM_APOLICE = '{this.ENDO_NUM_APOLICE}'
											AND SEQ_PROPOSTA = '{this.LTMVPROP_SEQ_PROPOSTA}'
											AND COD_MOVIMENTO = '9'
											AND SIT_MOVIMENTO IN ( '1' 
							, 'T' )
											WITH UR";

            return query;
        }
        public string LTMVPROP_COD_EXT_SEGURADO { get; set; }
        public string LTMVPROP_COD_CLASSE_ADESAO { get; set; }
        public string LTMVPROP_NUM_CLASSE_ADESAO { get; set; }
        public string LTMVPROP_COMPL_ENDER { get; set; }
        public string LTMVPROP_DT_INIVIG_PROPOSTA { get; set; }
        public string LTMVPROP_NUM_APOLICE { get; set; }
        public string LTMVPROP_QTD_PARCELAS { get; set; }
        public string LTMVPROP_VLR_JUROS_MENSAL { get; set; }
        public string LTMVPROP_VLR_CUSTO_APOLICE { get; set; }
        public string LTMVPROP_PCT_JUROS { get; set; }
        public string LTMVPROP_DATA_MOVIMENTO { get; set; }
        public string LTMVPROP_HORA_MOVIMENTO { get; set; }
        public string LTMVPROP_COD_MOVIMENTO { get; set; }
        public string LTMVPROP_SIT_MOVIMENTO { get; set; }
        public string LTMVPROP_COD_PRODUTO { get; set; }
        public string LTMVPROP_COD_EXT_ESTIP { get; set; }
        public string LTMVPROP_PCT_IOF { get; set; }
        public string LTMVPROP_CGCCPF { get; set; }
        public string LTMVPROP_IND_REGIAO { get; set; }
        public string LTMVPROP_PCT_DESC_FIDEL { get; set; }
        public string LTMVPROP_PCT_DESC_EXP { get; set; }
        public string LTMVPROP_PCT_DESC_AGRUP { get; set; }
        public string LTMVPROP_PCT_DESC_EQUIP { get; set; }
        public string LTMVPROP_PCT_DESC_BLINDAGEM { get; set; }
        public string LTMVPROP_NUM_PROPOSTA_SIM { get; set; }
        public string LTMVPROP_IND_TIPO_VIGENCIA { get; set; }
        public string LTMVPROP_QTD_REN_SEM_SINI { get; set; }
        public string LTMVPROP_QTD_REN_SEM_SINI_INF { get; set; }
        public string LTMVPROP_SEQ_PROPOSTA { get; set; }
        public string ENDO_NUM_APOLICE { get; set; }

        public static B2061_SELECT_LTMVPROP_DB_SELECT_2_Query1 Execute(B2061_SELECT_LTMVPROP_DB_SELECT_2_Query1 b2061_SELECT_LTMVPROP_DB_SELECT_2_Query1)
        {
            var ths = b2061_SELECT_LTMVPROP_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B2061_SELECT_LTMVPROP_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B2061_SELECT_LTMVPROP_DB_SELECT_2_Query1();
            var i = 0;
            dta.LTMVPROP_COD_EXT_SEGURADO = result[i++].Value?.ToString();
            dta.LTMVPROP_COD_CLASSE_ADESAO = result[i++].Value?.ToString();
            dta.LTMVPROP_NUM_CLASSE_ADESAO = result[i++].Value?.ToString();
            dta.LTMVPROP_COMPL_ENDER = result[i++].Value?.ToString();
            dta.LTMVPROP_DT_INIVIG_PROPOSTA = result[i++].Value?.ToString();
            dta.LTMVPROP_NUM_APOLICE = result[i++].Value?.ToString();
            dta.LTMVPROP_QTD_PARCELAS = result[i++].Value?.ToString();
            dta.LTMVPROP_VLR_JUROS_MENSAL = result[i++].Value?.ToString();
            dta.LTMVPROP_VLR_CUSTO_APOLICE = result[i++].Value?.ToString();
            dta.LTMVPROP_PCT_JUROS = result[i++].Value?.ToString();
            dta.LTMVPROP_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.LTMVPROP_HORA_MOVIMENTO = result[i++].Value?.ToString();
            dta.LTMVPROP_COD_MOVIMENTO = result[i++].Value?.ToString();
            dta.LTMVPROP_SIT_MOVIMENTO = result[i++].Value?.ToString();
            dta.LTMVPROP_COD_PRODUTO = result[i++].Value?.ToString();
            dta.LTMVPROP_COD_EXT_ESTIP = result[i++].Value?.ToString();
            dta.LTMVPROP_PCT_IOF = result[i++].Value?.ToString();
            dta.LTMVPROP_CGCCPF = result[i++].Value?.ToString();
            dta.LTMVPROP_IND_REGIAO = result[i++].Value?.ToString();
            dta.LTMVPROP_PCT_DESC_FIDEL = result[i++].Value?.ToString();
            dta.LTMVPROP_PCT_DESC_EXP = result[i++].Value?.ToString();
            dta.LTMVPROP_PCT_DESC_AGRUP = result[i++].Value?.ToString();
            dta.LTMVPROP_PCT_DESC_EQUIP = result[i++].Value?.ToString();
            dta.LTMVPROP_PCT_DESC_BLINDAGEM = result[i++].Value?.ToString();
            dta.LTMVPROP_NUM_PROPOSTA_SIM = result[i++].Value?.ToString();
            dta.LTMVPROP_IND_TIPO_VIGENCIA = result[i++].Value?.ToString();
            dta.LTMVPROP_QTD_REN_SEM_SINI = result[i++].Value?.ToString();
            dta.LTMVPROP_QTD_REN_SEM_SINI_INF = result[i++].Value?.ToString();
            return dta;
        }

    }
}