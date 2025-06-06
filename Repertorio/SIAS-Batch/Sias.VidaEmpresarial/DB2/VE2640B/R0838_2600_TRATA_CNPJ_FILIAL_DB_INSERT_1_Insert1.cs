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
    public class R0838_2600_TRATA_CNPJ_FILIAL_DB_INSERT_1_Insert1 : QueryBasis<R0838_2600_TRATA_CNPJ_FILIAL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_ESTIPULANTE_VINCULO
            ( NUM_APOLICE,
            COD_SUBGRUPO,
            NUM_CNPJ,
            SEQ_ESTIP_VINC,
            STA_ATIVO,
            COD_USUARIO,
            NOM_PROGRAMA,
            DTH_CADASTRAMENTO,
            DTH_ATUALIZACAO)
            VALUES
            (:VG133-NUM-APOLICE,
            :VG133-COD-SUBGRUPO,
            :VG133-NUM-CNPJ,
            :VG133-SEQ-ESTIP-VINC,
            :VG133-STA-ATIVO,
            :VG133-COD-USUARIO,
            :VG133-NOM-PROGRAMA,
            CURRENT TIMESTAMP,
            CURRENT TIMESTAMP)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_ESTIPULANTE_VINCULO ( NUM_APOLICE, COD_SUBGRUPO, NUM_CNPJ, SEQ_ESTIP_VINC, STA_ATIVO, COD_USUARIO, NOM_PROGRAMA, DTH_CADASTRAMENTO, DTH_ATUALIZACAO) VALUES ({FieldThreatment(this.VG133_NUM_APOLICE)}, {FieldThreatment(this.VG133_COD_SUBGRUPO)}, {FieldThreatment(this.VG133_NUM_CNPJ)}, {FieldThreatment(this.VG133_SEQ_ESTIP_VINC)}, {FieldThreatment(this.VG133_STA_ATIVO)}, {FieldThreatment(this.VG133_COD_USUARIO)}, {FieldThreatment(this.VG133_NOM_PROGRAMA)}, CURRENT TIMESTAMP, CURRENT TIMESTAMP)";

            return query;
        }
        public string VG133_NUM_APOLICE { get; set; }
        public string VG133_COD_SUBGRUPO { get; set; }
        public string VG133_NUM_CNPJ { get; set; }
        public string VG133_SEQ_ESTIP_VINC { get; set; }
        public string VG133_STA_ATIVO { get; set; }
        public string VG133_COD_USUARIO { get; set; }
        public string VG133_NOM_PROGRAMA { get; set; }

        public static void Execute(R0838_2600_TRATA_CNPJ_FILIAL_DB_INSERT_1_Insert1 r0838_2600_TRATA_CNPJ_FILIAL_DB_INSERT_1_Insert1)
        {
            var ths = r0838_2600_TRATA_CNPJ_FILIAL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0838_2600_TRATA_CNPJ_FILIAL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}