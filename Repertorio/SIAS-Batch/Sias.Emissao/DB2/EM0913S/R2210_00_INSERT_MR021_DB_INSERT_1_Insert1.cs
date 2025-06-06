using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0913S
{
    public class R2210_00_INSERT_MR021_DB_INSERT_1_Insert1 : QueryBasis<R2210_00_INSERT_MR021_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.MR_APOL_ITEM_COND
            (NUM_APOLICE,
            NUM_ENDOSSO,
            NUM_ITEM,
            NUM_TP_CONDOMINIO,
            NUM_PAVIMENTOS,
            NUM_ELEVADORES,
            NUM_PORTAO_ELETRON,
            NUM_VAGAS,
            NUM_UNID_AUTONOMA,
            PCT_DESC_COBERTURA,
            PCT_BONUS_RENOVCAO,
            PCT_DESC_PROMOCAO,
            PCT_DESC_CORRETOR,
            DTH_CADASTRAMENTO ,
            COD_BENEFICIARIO,
            DES_CLAUSULA_BENEF)
            VALUES (:MR021-NUM-APOLICE,
            :MR021-NUM-ENDOSSO,
            :MR021-NUM-ITEM,
            :MR021-NUM-TP-CONDOMINIO,
            :MR021-NUM-PAVIMENTOS,
            :MR021-NUM-ELEVADORES,
            :MR021-NUM-PORTAO-ELETRON,
            :MR021-NUM-VAGAS,
            :MR021-NUM-UNID-AUTONOMA,
            :MR021-PCT-DESC-COBERTURA,
            :MR021-PCT-BONUS-RENOVCAO,
            :MR021-PCT-DESC-PROMOCAO,
            :MR021-PCT-DESC-CORRETOR,
            CURRENT TIMESTAMP ,
            :MR021-COD-BENEFICIARIO :WNULL-COD-COND ,
            :MR021-DES-CLAUSULA-BENEF :WNULL-DES-COND )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.MR_APOL_ITEM_COND (NUM_APOLICE, NUM_ENDOSSO, NUM_ITEM, NUM_TP_CONDOMINIO, NUM_PAVIMENTOS, NUM_ELEVADORES, NUM_PORTAO_ELETRON, NUM_VAGAS, NUM_UNID_AUTONOMA, PCT_DESC_COBERTURA, PCT_BONUS_RENOVCAO, PCT_DESC_PROMOCAO, PCT_DESC_CORRETOR, DTH_CADASTRAMENTO , COD_BENEFICIARIO, DES_CLAUSULA_BENEF) VALUES ({FieldThreatment(this.MR021_NUM_APOLICE)}, {FieldThreatment(this.MR021_NUM_ENDOSSO)}, {FieldThreatment(this.MR021_NUM_ITEM)}, {FieldThreatment(this.MR021_NUM_TP_CONDOMINIO)}, {FieldThreatment(this.MR021_NUM_PAVIMENTOS)}, {FieldThreatment(this.MR021_NUM_ELEVADORES)}, {FieldThreatment(this.MR021_NUM_PORTAO_ELETRON)}, {FieldThreatment(this.MR021_NUM_VAGAS)}, {FieldThreatment(this.MR021_NUM_UNID_AUTONOMA)}, {FieldThreatment(this.MR021_PCT_DESC_COBERTURA)}, {FieldThreatment(this.MR021_PCT_BONUS_RENOVCAO)}, {FieldThreatment(this.MR021_PCT_DESC_PROMOCAO)}, {FieldThreatment(this.MR021_PCT_DESC_CORRETOR)}, CURRENT TIMESTAMP ,  {FieldThreatment((this.WNULL_COD_COND?.ToInt() == -1 ? null : this.MR021_COD_BENEFICIARIO))} ,  {FieldThreatment((this.WNULL_DES_COND?.ToInt() == -1 ? null : this.MR021_DES_CLAUSULA_BENEF))} )";

            return query;
        }
        public string MR021_NUM_APOLICE { get; set; }
        public string MR021_NUM_ENDOSSO { get; set; }
        public string MR021_NUM_ITEM { get; set; }
        public string MR021_NUM_TP_CONDOMINIO { get; set; }
        public string MR021_NUM_PAVIMENTOS { get; set; }
        public string MR021_NUM_ELEVADORES { get; set; }
        public string MR021_NUM_PORTAO_ELETRON { get; set; }
        public string MR021_NUM_VAGAS { get; set; }
        public string MR021_NUM_UNID_AUTONOMA { get; set; }
        public string MR021_PCT_DESC_COBERTURA { get; set; }
        public string MR021_PCT_BONUS_RENOVCAO { get; set; }
        public string MR021_PCT_DESC_PROMOCAO { get; set; }
        public string MR021_PCT_DESC_CORRETOR { get; set; }
        public string MR021_COD_BENEFICIARIO { get; set; }
        public string WNULL_COD_COND { get; set; }
        public string MR021_DES_CLAUSULA_BENEF { get; set; }
        public string WNULL_DES_COND { get; set; }

        public static void Execute(R2210_00_INSERT_MR021_DB_INSERT_1_Insert1 r2210_00_INSERT_MR021_DB_INSERT_1_Insert1)
        {
            var ths = r2210_00_INSERT_MR021_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2210_00_INSERT_MR021_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}