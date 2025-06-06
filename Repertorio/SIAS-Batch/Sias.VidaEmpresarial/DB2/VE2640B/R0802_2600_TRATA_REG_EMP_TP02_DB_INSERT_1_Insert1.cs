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
    public class R0802_2600_TRATA_REG_EMP_TP02_DB_INSERT_1_Insert1 : QueryBasis<R0802_2600_TRATA_REG_EMP_TP02_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_MOV_FUNCIONARIO
            (NUM_PROPOSTA_SIVPF,
            DTH_INI_VIGENCIA,
            NUM_CPF,
            DTH_FIM_VIGENCIA,
            NUM_NIVEL_CARGO,
            NUM_MATRICULA,
            NOM_FUNCIONARIO,
            DTH_NASCIMENTO,
            NUM_IDADE,
            STA_SEXO,
            STA_ESTADO_CIVIL,
            COD_PROFISSAO,
            IND_REPR_EMPRE,
            IND_IMP_DPS,
            DES_MOTIVO,
            NUM_DDD,
            NUM_TELEFONE,
            NUM_RG,
            COD_ORGAO_RG,
            COD_UF_ORGAO_RG,
            DTH_EMISSAO_RG,
            STA_FUNCIONARIO,
            COD_USUARIO,
            DTH_TIMESTAMP)
            VALUES
            (:VGMOVFUN-NUM-PROPOSTA-SIVPF,
            :VGMOVFUN-DTH-INI-VIGENCIA,
            :VGMOVFUN-NUM-CPF,
            :VGMOVFUN-DTH-FIM-VIGENCIA,
            :VGMOVFUN-NUM-NIVEL-CARGO,
            :VGMOVFUN-NUM-MATRICULA,
            :VGMOVFUN-NOM-FUNCIONARIO,
            :VGMOVFUN-DTH-NASCIMENTO,
            :VGMOVFUN-NUM-IDADE,
            :VGMOVFUN-STA-SEXO,
            :VGMOVFUN-STA-ESTADO-CIVIL,
            :VGMOVFUN-COD-PROFISSAO,
            :VGMOVFUN-IND-REPR-EMPRE,
            :VGMOVFUN-IND-IMP-DPS,
            :VGMOVFUN-DES-MOTIVO,
            :VGMOVFUN-NUM-DDD,
            :VGMOVFUN-NUM-TELEFONE,
            :VGMOVFUN-NUM-RG,
            :VGMOVFUN-COD-ORGAO-RG,
            :VGMOVFUN-COD-UF-ORGAO-RG,
            :VGMOVFUN-DTH-EMISSAO-RG,
            :VGMOVFUN-STA-FUNCIONARIO,
            :VGMOVFUN-COD-USUARIO,
            CURRENT TIMESTAMP)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_MOV_FUNCIONARIO (NUM_PROPOSTA_SIVPF, DTH_INI_VIGENCIA, NUM_CPF, DTH_FIM_VIGENCIA, NUM_NIVEL_CARGO, NUM_MATRICULA, NOM_FUNCIONARIO, DTH_NASCIMENTO, NUM_IDADE, STA_SEXO, STA_ESTADO_CIVIL, COD_PROFISSAO, IND_REPR_EMPRE, IND_IMP_DPS, DES_MOTIVO, NUM_DDD, NUM_TELEFONE, NUM_RG, COD_ORGAO_RG, COD_UF_ORGAO_RG, DTH_EMISSAO_RG, STA_FUNCIONARIO, COD_USUARIO, DTH_TIMESTAMP) VALUES ({FieldThreatment(this.VGMOVFUN_NUM_PROPOSTA_SIVPF)}, {FieldThreatment(this.VGMOVFUN_DTH_INI_VIGENCIA)}, {FieldThreatment(this.VGMOVFUN_NUM_CPF)}, {FieldThreatment(this.VGMOVFUN_DTH_FIM_VIGENCIA)}, {FieldThreatment(this.VGMOVFUN_NUM_NIVEL_CARGO)}, {FieldThreatment(this.VGMOVFUN_NUM_MATRICULA)}, {FieldThreatment(this.VGMOVFUN_NOM_FUNCIONARIO)}, {FieldThreatment(this.VGMOVFUN_DTH_NASCIMENTO)}, {FieldThreatment(this.VGMOVFUN_NUM_IDADE)}, {FieldThreatment(this.VGMOVFUN_STA_SEXO)}, {FieldThreatment(this.VGMOVFUN_STA_ESTADO_CIVIL)}, {FieldThreatment(this.VGMOVFUN_COD_PROFISSAO)}, {FieldThreatment(this.VGMOVFUN_IND_REPR_EMPRE)}, {FieldThreatment(this.VGMOVFUN_IND_IMP_DPS)}, {FieldThreatment(this.VGMOVFUN_DES_MOTIVO)}, {FieldThreatment(this.VGMOVFUN_NUM_DDD)}, {FieldThreatment(this.VGMOVFUN_NUM_TELEFONE)}, {FieldThreatment(this.VGMOVFUN_NUM_RG)}, {FieldThreatment(this.VGMOVFUN_COD_ORGAO_RG)}, {FieldThreatment(this.VGMOVFUN_COD_UF_ORGAO_RG)}, {FieldThreatment(this.VGMOVFUN_DTH_EMISSAO_RG)}, {FieldThreatment(this.VGMOVFUN_STA_FUNCIONARIO)}, {FieldThreatment(this.VGMOVFUN_COD_USUARIO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string VGMOVFUN_NUM_PROPOSTA_SIVPF { get; set; }
        public string VGMOVFUN_DTH_INI_VIGENCIA { get; set; }
        public string VGMOVFUN_NUM_CPF { get; set; }
        public string VGMOVFUN_DTH_FIM_VIGENCIA { get; set; }
        public string VGMOVFUN_NUM_NIVEL_CARGO { get; set; }
        public string VGMOVFUN_NUM_MATRICULA { get; set; }
        public string VGMOVFUN_NOM_FUNCIONARIO { get; set; }
        public string VGMOVFUN_DTH_NASCIMENTO { get; set; }
        public string VGMOVFUN_NUM_IDADE { get; set; }
        public string VGMOVFUN_STA_SEXO { get; set; }
        public string VGMOVFUN_STA_ESTADO_CIVIL { get; set; }
        public string VGMOVFUN_COD_PROFISSAO { get; set; }
        public string VGMOVFUN_IND_REPR_EMPRE { get; set; }
        public string VGMOVFUN_IND_IMP_DPS { get; set; }
        public string VGMOVFUN_DES_MOTIVO { get; set; }
        public string VGMOVFUN_NUM_DDD { get; set; }
        public string VGMOVFUN_NUM_TELEFONE { get; set; }
        public string VGMOVFUN_NUM_RG { get; set; }
        public string VGMOVFUN_COD_ORGAO_RG { get; set; }
        public string VGMOVFUN_COD_UF_ORGAO_RG { get; set; }
        public string VGMOVFUN_DTH_EMISSAO_RG { get; set; }
        public string VGMOVFUN_STA_FUNCIONARIO { get; set; }
        public string VGMOVFUN_COD_USUARIO { get; set; }

        public static void Execute(R0802_2600_TRATA_REG_EMP_TP02_DB_INSERT_1_Insert1 r0802_2600_TRATA_REG_EMP_TP02_DB_INSERT_1_Insert1)
        {
            var ths = r0802_2600_TRATA_REG_EMP_TP02_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0802_2600_TRATA_REG_EMP_TP02_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}