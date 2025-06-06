using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0617B
{
    public class R3400_TRATA_BENEFICIARIOS_DB_INSERT_1_Insert1 : QueryBasis<R3400_TRATA_BENEFICIARIOS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.BENEF_PROP_AZUL VALUES
            (:DCLBENEF-PROP-AZUL.NUM-PROPOSTA-AZUL,
            :DCLBENEF-PROP-AZUL.COD-AGENCIA-LOTE,
            :DCLBENEF-PROP-AZUL.DATA-LOTE,
            :DCLBENEF-PROP-AZUL.NUM-LOTE,
            :DCLBENEF-PROP-AZUL.NUM-SEQ-LOTE,
            :DCLBENEF-PROP-AZUL.NUM-BENEFICIARIO,
            :DCLBENEF-PROP-AZUL.NOME-BENEFICIARIO,
            :DCLBENEF-PROP-AZUL.GRAU-PARENTESCO,
            :DCLBENEF-PROP-AZUL.PCT-PART-BENEFICIA,
            :DCLBENEF-PROP-AZUL.DATA-NASCIMENTO:VIND-DTNASBENEF)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.BENEF_PROP_AZUL VALUES ({FieldThreatment(this.NUM_PROPOSTA_AZUL)}, {FieldThreatment(this.COD_AGENCIA_LOTE)}, {FieldThreatment(this.DATA_LOTE)}, {FieldThreatment(this.NUM_LOTE)}, {FieldThreatment(this.NUM_SEQ_LOTE)}, {FieldThreatment(this.NUM_BENEFICIARIO)}, {FieldThreatment(this.NOME_BENEFICIARIO)}, {FieldThreatment(this.GRAU_PARENTESCO)}, {FieldThreatment(this.PCT_PART_BENEFICIA)},  {FieldThreatment((this.VIND_DTNASBENEF?.ToInt() == -1 ? null : this.DATA_NASCIMENTO))})";

            return query;
        }
        public string NUM_PROPOSTA_AZUL { get; set; }
        public string COD_AGENCIA_LOTE { get; set; }
        public string DATA_LOTE { get; set; }
        public string NUM_LOTE { get; set; }
        public string NUM_SEQ_LOTE { get; set; }
        public string NUM_BENEFICIARIO { get; set; }
        public string NOME_BENEFICIARIO { get; set; }
        public string GRAU_PARENTESCO { get; set; }
        public string PCT_PART_BENEFICIA { get; set; }
        public string DATA_NASCIMENTO { get; set; }
        public string VIND_DTNASBENEF { get; set; }

        public static void Execute(R3400_TRATA_BENEFICIARIOS_DB_INSERT_1_Insert1 r3400_TRATA_BENEFICIARIOS_DB_INSERT_1_Insert1)
        {
            var ths = r3400_TRATA_BENEFICIARIOS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3400_TRATA_BENEFICIARIOS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}