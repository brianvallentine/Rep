using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB060_ALTERA_TERMO_ADESAO_DB_UPDATE_1_Update1 : QueryBasis<DB060_ALTERA_TERMO_ADESAO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.TERMO_ADESAO
				SET NUM_APOLICE =  '{this.TERMOADE_NUM_APOLICE}',
				COD_SUBGRUPO =  '{this.TERMOADE_COD_SUBGRUPO}',
				PCCOMGER =  '{this.TERMOADE_PCCOMGER}',
				PCCOMVEN =  '{this.TERMOADE_PCCOMVEN}',
				COD_CORRETOR =  '{this.TERMOADE_COD_CORRETOR}',
				PCCOMCOR =  '{this.TERMOADE_PCCOMCOR}',
				COD_MOEDA_IMP =  '{this.TERMOADE_COD_MOEDA_IMP}',
				COD_MOEDA_PRM =  '{this.TERMOADE_COD_MOEDA_PRM}',
				MODALIDADE_CAPITAL =  '{this.TERMOADE_MODALIDADE_CAPITAL}',
				VAL_CONTRATADO =  '{this.TERMOADE_VAL_CONTRATADO}',
				QUANT_VIDAS =  '{this.TERMOADE_QUANT_VIDAS}',
				PERI_PAGAMENTO =  '{this.TERMOADE_PERI_PAGAMENTO}'
				WHERE 
				NUM_TERMO =  '{this.TERMOADE_NUM_TERMO}'";

            return query;
        }
        public string TERMOADE_MODALIDADE_CAPITAL { get; set; }
        public string TERMOADE_VAL_CONTRATADO { get; set; }
        public string TERMOADE_PERI_PAGAMENTO { get; set; }
        public string TERMOADE_COD_MOEDA_IMP { get; set; }
        public string TERMOADE_COD_MOEDA_PRM { get; set; }
        public string TERMOADE_COD_SUBGRUPO { get; set; }
        public string TERMOADE_COD_CORRETOR { get; set; }
        public string TERMOADE_NUM_APOLICE { get; set; }
        public string TERMOADE_QUANT_VIDAS { get; set; }
        public string TERMOADE_PCCOMGER { get; set; }
        public string TERMOADE_PCCOMVEN { get; set; }
        public string TERMOADE_PCCOMCOR { get; set; }
        public string TERMOADE_NUM_TERMO { get; set; }

        public static void Execute(DB060_ALTERA_TERMO_ADESAO_DB_UPDATE_1_Update1 dB060_ALTERA_TERMO_ADESAO_DB_UPDATE_1_Update1)
        {
            var ths = dB060_ALTERA_TERMO_ADESAO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB060_ALTERA_TERMO_ADESAO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}